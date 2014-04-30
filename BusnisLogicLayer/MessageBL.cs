using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer;
using EntityModel;


namespace BusinessLogicLayer
{
   public class MessageBL
    {
       public static List<EntityModel.Message> getAllMessage()
       {
           List<EntityModel.Message> n = new List<EntityModel.Message>();
           n = DataAccesLayer.MessageDAL.getAllMessage();
           return n;
       
       }

      
       public static void newMessage(EntityModel.Message msj)
       {
           DataAccesLayer.MessageDAL.newMessage(msj);
       }

    }
}
