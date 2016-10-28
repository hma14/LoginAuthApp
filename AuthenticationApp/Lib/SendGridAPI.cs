using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuthenticationApp.Lib
{
    public class SendGridAPI
    {
        public static async Task<string> SendEmail(IdentityMessage message)
        {

            //String apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY", EnvironmentVariableTarget.User);
            String apiKey = ConfigurationManager.AppSettings["SENDGRID_APIKEY"];

            dynamic sg = new SendGridAPIClient(apiKey, "https://api.sendgrid.com");

            Email From = new Email(ConfigurationManager.AppSettings["FROM_EMAIL"]);
            Email To = new Email(message.Destination);
            SendGrid.Helpers.Mail.Content content = new SendGrid.Helpers.Mail.Content("text/html", message.Body);
            Mail mail = new Mail(From, message.Subject, To, content);

            //mail.TemplateId = "13b8f94f-bcae-4ec6-b752-70d6cb59f932";
            mail.Personalization[0].AddSubstitution("-name-", "www.lottotry.com");

            try
            {
                dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
                return response.StatusCode.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}