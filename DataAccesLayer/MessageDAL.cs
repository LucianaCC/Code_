using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModel;


namespace DataAccesLayer
{
   public  class MessageDAL
    {
     

       public MessageDAL() { }

       public static List<EntityModel.Message> getAllMessage ( )
        {
          try{
  
              using (var Contexto = new WBTaskEntities1())
               {
                   var query = (from c in Contexto.Messsage    
                                orderby c.Date descending
                                select c);
                   List<EntityModel.Message> list = new List<EntityModel.Message>();
                   foreach (DataAccesLayer.Messsage item in query)
                   {
                       EntityModel.Message message = new EntityModel.Message();
                       message.Text = item.Text;
                       message.Autor = item.Account.Nombre;
                       message.Email = item.Account.Email;
                       message.DateFromNow = GetDateFromNow.getDateFromNow(item.Date);
                       message.Date = (DateTime) item.Date;
                       list.Add(message);
                   }
                   return list; 
               }

          }
          catch (Exception ex)
          {
              throw ex;
          } 
        }
       public static void newMessage(EntityModel.Message msj)
        {
            try{
           
                    using (var Contexto = new WBTaskEntities1())
                    {
                        DataAccesLayer.Messsage msg = new DataAccesLayer.Messsage();
                        msg.Date = DateTime.Now.ToLocalTime();
                        msg.IdAccount = msj.Account.IdAccount;
                        msg.Text = msj.Text;
                        Contexto.AddToMesssage(msg);
                        Contexto.SaveChanges();
                        Contexto.Refresh(System.Data.Objects.RefreshMode.StoreWins, msg);

                    }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
        
           
    }
}


