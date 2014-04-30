using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using BusinessLogicLayer;
using EntityModel;
using System.Web.Script.Services;
using System.Data;
using System.Configuration;

namespace MessageExpress
{
    [ServiceContract(Namespace = "WebService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ScriptService]
    public class WebService
    {
        // Para usar HTTP GET, agregue el atributo [WebGet]. (El valor predeterminado de ResponseFormat es WebMessageFormat.Json)
        // Para crear una operación que devuelva XML,
        //     agregue [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     e incluya la siguiente línea en el cuerpo de la operación:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
       
        public List<EntityModel.Message> Message_getAllMessage()
        {
            // Agregue aquí la implementación de la operación
            return MessageBL.getAllMessage();
        }

        [OperationContract]
        public void Message_newMessage(EntityModel.Message msj)
        {
            // Agregue aquí la implementación de la operación
            //MessageBL.newMessage(text, idaccount);
            MessageBL.newMessage(msj);
        }
        // Agregue aquí más operaciones y márquelas con [OperationContract]
    }
}
