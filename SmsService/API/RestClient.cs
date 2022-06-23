using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.API
{
    public class RestClient
    {
        public HttpClient _Client;
        //public RestClient()
        //{
        //    _Client = new HttpClient();
        //}
        //string username = "tscdxb";
        //string password = "36988604";
        //string mobilenumber = "971502263418";
        //string message = "testmessage";
        //string sid = "SMSCOUNTRY";
       
        public async Task<bool> GetQueryStringAsync()
        {
            var query = new Dictionary<string, string>()
            {
                ["User"] = "tscdxb",
                ["passwd"] = "36988604",
                ["mobilenumber"] = "971502263418",
                ["message"] = "testmessage",
                ["sid"] = "SMSCOUNTRY"
            };
            using(_Client=new HttpClient())
            {
                var uri = QueryHelpers.AddQueryString("http://api.smscountry.com/SMSCwebservice_bulk.aspx", query);

                var result = await _Client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                     return  true;
                }
                return false;
            }

            //var query = new Dictionary<string, string>()
            //{
            //    ["User"] = "tscdxb",
            //    ["passwd"] = "36988604",
            //    ["mobilenumber"] = "971502263418",
            //    ["message"] = "testmessage",
            //    ["sid"] = "SMSCOUNTRY"

            //};

            //string response = await _Client.GetStringAsync("http://api.smscountry.com/SMSCwebservice_bulk.aspx?User=xxxxxx&passwd=" +
            //                                                 "xxxxxxxxxxxx & mobilenumber = xxxxxxxxxx & message = xxxxxxxxx & sid = xxxxxxxx & mtype = N & DR = Y");
        }
        //string authKey;
        //string token;

        //public RestClient(string authKey,string token)
        //{
        //    this.authKey = authKey;
        //    this.token = token;
        //    _Client = new HttpClient();
        //}

        //public async Task<bool> PostSms(string message, string receipientnum)
        //{
        //    try
        //    {
        //        using (_Client= new HttpClient())
        //        {
        //            var body =  new{
        //                Text = "Sample text sms",
        //                Number = "971502263418",
        //                SenderId = "SMSCountry",
        //                DRNotifyUrl = "https://www.domainname.com/notifyurl",
        //                DRNotifyHttpMethod = "POST",
        //                Tool = "API"};

        //            var json = JsonConvert.SerializeObject(body);

        //            var authorsn = Generateauthtoken(authKey,token);
                    

        //            _Client.BaseAddress = new Uri("https://restapi.smscountry.com/v0.1/");
        //            _Client.DefaultRequestHeaders.Accept.Clear();
        //            _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorsn);
        //            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            var response = _Client.PostAsJsonAsync( "Accounts/authKey/SMSes/", json).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception)   
        //    {
        //        return false;
        //    }

        //}

        //private string Generateauthtoken(string authKey, string token)
        //{
        //    return Base64Encode($"{authKey}:{token}");
        //}

        //private static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
        //private static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}
    }
}
