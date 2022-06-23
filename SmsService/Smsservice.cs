using SmsService.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsService
{
    public class Smsservice
    {

        //string authKey;
        //string token;
        RestClient client;
        

        public Smsservice()
        {
         client = new RestClient();
        }
        //public Smsservice(string authKey, string token)
        //{
        //    this.authKey = authKey;
        //    this.token = token;
        //    client = new RestClient(authKey,token);
        //}
        //public async Task<bool> SendSms(string Message,string recipientnum)
        //{
        //    var result = await client.PostSms(Message,recipientnum);
        //    return result;
        //}
        public async Task SendSms()
        {
          await client.GetQueryStringAsync();

        }



    }
}
