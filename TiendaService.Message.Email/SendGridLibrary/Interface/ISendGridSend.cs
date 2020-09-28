using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaService.Message.Email.SendGridLibrary.Models;

namespace TiendaService.Message.Email.SendGridLibrary.Interface
{
    public interface ISendGridSend
    {
        Task<(bool Result, string errorMessage)> SendEmail(Data data);
    }
}
