using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;

namespace AuthenticationApp.Lib
{
    public class SmsApi
    {
        public static Task SendSms(IdentityMessage message)
        {
#if true
            var Twilio = new TwilioRestClient(ConfigurationManager.AppSettings["SMSAccountIdentification"],
                                              ConfigurationManager.AppSettings["SMSAccountPassword"]);
#else
            var Twilio = new TwilioRestClient(Environment.GetEnvironmentVariable("SMSAccountIdentification", EnvironmentVariableTarget.User),
                                             Environment.GetEnvironmentVariable("SMSAccountPassword", EnvironmentVariableTarget.User));
#endif

            var result = Twilio.SendMessage(ConfigurationManager.AppSettings["SMSAccountFrom"],
                                            message.Destination, message.Body);

            // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            Trace.TraceInformation(result.Status);

            // Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);

        }
    }
}