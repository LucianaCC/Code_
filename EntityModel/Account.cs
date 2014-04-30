using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityModel
{
    public class Account
    {
        private int _IdAccount = new int();
        private string _Name = string.Empty;
        private string _Email = string.Empty;
        private string _Password = string.Empty;

        public int IdAccount
        {
            get
            { return _IdAccount; }
            set
            { _IdAccount = value; }
        }


        public string Name
        {
            get
            { return _Name; }
            set
            { _Name = value; }
        }

        public string Email
        {
            get
            { return _Email; }
            set
            { _Email = value; }
        }

        public string Password
        {
            get
            { return _Password; }
            set
            { _Password = value; }
        }

       
    }
}
