using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.ViewModel
{
    public class ContactViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string NamePlaceHolder { get; set; }
        public string EmailPlaceHolder { get; set; }
        public string MessagePlaceHolder { get; set; }
        public string ContactGDPRMessage { get; set; }
        public string SubmitButtonText { get; set; }
    }
}