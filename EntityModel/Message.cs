using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityModel
{
    public class Message
    {
        public Message() { }


        private string _name = string.Empty;

        private int _IdMessage = new int();
        private string _Text = string.Empty;
        private DateTime _Date = new DateTime();
        private Account _Account = new Account();
        private string _Autor = string.Empty;
        private string _DateFromNow = string.Empty;
        private string _Email = string.Empty;
        private string _Gravatar = string.Empty;


        public int IdMessage
        {
            get
            { return _IdMessage; }
            set
            { _IdMessage = value; }
        }
        
        public string Text
        {
         get
         {return _Text;}
         set
         {_Text = value;}
        }    
        
        public string Autor
        {
         get
         {return _Autor;}
         set
         {_Autor = value;}
        }

        public string DateFromNow
        {
         get
         {return _DateFromNow;}
         set
         {_DateFromNow = value;}
        }

         public string Email
        {
         get
         {return _Email;}
         set
         {_Email = value;}
        } 
 
        public string Gravatar
        {
         get
         {return _Gravatar;}
         set
         {_Gravatar = value;}
        }

        public Account Account
        {
         get
         {return _Account;}
         set
         {_Account = value;}
        }

         public DateTime Date
        {
         get
         {return _Date;}
         set
         {_Date = value;}
        }

       
        
    }
}
