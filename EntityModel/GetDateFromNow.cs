using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityModel
{
   public static  class GetDateFromNow
    {

       public static string getDateFromNow(this DateTime date)

        {
            DateTime now = DateTime.Now;           
            TimeSpan diference;
            
           string prefijo = "{0} {1} ago";    

           diference = now.Subtract(date);

           if (diference.Ticks < 0) 
           {
               prefijo = "Dentro de {0} {1}";
               diference = diference.Negate();  

           }

           
           if (diference.Days >= 7) 
               return String.Format("El {0} a las {1}", date.ToLongDateString(), date.ToLongTimeString());

           else if (diference.Days >= 2) 
               return String.Format(prefijo, diference.Days, "days");

           else if (diference.Days == 1) 
               return "yesterday";

           else if (diference.Hours >= 2)
               return String.Format(prefijo, diference.Hours, "hours");

          else if (diference.Minutes >= 2)
               return String.Format(prefijo, diference.Minutes, "minutes");

           else 
               return String.Format(prefijo, Math.Floor(diference.TotalSeconds), "seconds");

  

    }
}

}