using SmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Crm.CEP.Sms
{
    public class SmsAppService: ITransientDependency
    {
        //private readonly ISmsSender _smsSender;

        //public SmsAppService(ISmsSender smsSender)
        //{

        //    _smsSender = smsSender;
        //}

        //public async Task DoItAsync()
        //{

        //    Smsservice smsservice = new Smsservice("","");
        //    var res= smsservice.SendSms("test", "+012345678901");
            
            

            //await _smsSender.SendAsync(
            //    "+012345678901",        // target phone number
            //    "This is test sms..."   // message text
            //);
        //}
    }
}
