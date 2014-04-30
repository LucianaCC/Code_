using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModel;
using DataAccesLayer;

namespace BusinessLogicLayer
{
   public class AccountBL
    {
       public static bool Check(string password, string email)
       {

           bool validate = DataAccesLayer.AccountDAL.verifyAccount(password, email);
          return validate; 
       }


       public static EntityModel.Account getUser(string password, string user)
       {

           EntityModel.Account validate = DataAccesLayer.AccountDAL.getUser(password, user);
           return validate;
       }
    }
}
