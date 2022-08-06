using Crm.CEP.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;
using Crm.CEP.EntityFrameworkCore;

namespace Crm.CEP.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController: AbpControllerBase
    {
        public static User user = new User();

        private readonly CEPDbContext _cEPDbContext;

        private  readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public AuthController(Microsoft.Extensions.Configuration.IConfiguration configuration, CEPDbContext cEPDbContext)
        {
            _configuration = configuration;
            _cEPDbContext = cEPDbContext;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.Username = request.Username;
            user.PasswordSalt = passwordSalt;
            await _cEPDbContext.User.AddAsync(user);
            await _cEPDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var dbUser = _cEPDbContext.User.Where(u => u.Username == request.Username).FirstOrDefault();
            if (dbUser == null)
            {
                return BadRequest("User not found");
            }
            var retrievedusername = _cEPDbContext.User.Where(p => p.Id == dbUser.Id).Select(u => u.Username).FirstOrDefault();
            var retrievedpasswordhash = _cEPDbContext.User.Where(p => p.Id == dbUser.Id).Select(u => u.PasswordHash).FirstOrDefault();
            var retrievedsalt = _cEPDbContext.User.Where(p => p.Id == dbUser.Id).Select(u => u.PasswordSalt).FirstOrDefault();
            try
            {
                //if (dbUser == null)
                //{
                //    return BadRequest("User not found");
                //}

                if (!VerifyPasswordHash(request.Password, retrievedpasswordhash, retrievedsalt))
                {
                    return BadRequest("Wrong password or username combination");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //if (user.Username != request.Username)
            //{
            //    return BadRequest("User not found");

            //}                                                             
            //if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            //{
            //    return BadRequest("Wrong password");
            //}
            user.Username = dbUser.Username;
            string Token = CreateToken(user);
       return Ok(Token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds); 

            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }

}