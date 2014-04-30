using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using EntityModel;

namespace DataAccesLayer
{
    public class AccountDAL
    {
        public AccountDAL() { }

        public static bool verifyAccount(string password, string email)
        {
            try
            {
                using (var Contexto = new WBTaskEntities1())
                {
                    var query = (from c in Contexto.Account
                                 where c.PassWord == password && c.Email == email
                                 select c);

                    if (query.Count() != 0)
                    {
                        return true;


                    }
                    else
                    { return false; }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static EntityModel.Account getUser(string password, string email)
        {
            EntityModel.Account user = new EntityModel.Account();
            try
            {
                using (var Contexto = new WBTaskEntities1())
                {
                    var query = (from c in Contexto.Account
                                 where c.PassWord == password && c.Email == email
                                 select c);

                    var userlogined = query.First<Account>();
                    user.IdAccount = userlogined.IdAccount;
                    user.Email = userlogined.Email;
                    user.Name = userlogined.Nombre;
                    user.Password = userlogined.PassWord;

                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public static EntityModel.Account getUserbyid(int id)
        {
            try
            {

                EntityModel.Account user = new EntityModel.Account();
                
                    using (var Contexto = new WBTaskEntities1())
                    {
                        var query = (from c in Contexto.Account
                                     where c.IdAccount == id
                                     select c);

                        var userlogined = query.First<Account>();
                        user.IdAccount = userlogined.IdAccount;
                        user.Email = userlogined.Email;
                        user.Name = userlogined.Nombre;
                        user.Password = userlogined.PassWord;
                    }
                    return user;
                }

                catch (Exception ex)
                {
                    throw ex;
                }



            }




        }
    }


