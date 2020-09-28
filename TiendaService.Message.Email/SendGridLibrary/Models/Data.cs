using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaService.Message.Email.SendGridLibrary.Models
{
    public class Data
    {
        public string SendGridApiKey { get; set; }
        public string To { get; set; }
        public string NameTo { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
