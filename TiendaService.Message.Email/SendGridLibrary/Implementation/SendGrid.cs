using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaService.Message.Email.SendGridLibrary.Interface;
using TiendaService.Message.Email.SendGridLibrary.Models;

namespace TiendaService.Message.Email.SendGridLibrary.Implementation
{
    public class SendGridSend : ISendGridSend
    {
        public async System.Threading.Tasks.Task<(bool Result, string errorMessage)> SendEmail(Data data)
        {

            try
            {
                var sendGridClient = new SendGridClient(data.SendGridApiKey);
                var to = new EmailAddress(data.To, data.NameTo);
                var title = data.Title;

                var sender = new EmailAddress("aiglesias.milco@gmail.com", "Armando Iglesias");

                var content = data.Body;

                var message = MailHelper.CreateSingleEmail(sender, to, title, content, content);

                await sendGridClient.SendEmailAsync(message);

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }

            

            

        }
    }
}
