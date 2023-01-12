using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyWeb2
{
    /// <summary>
    /// Summary description for BetterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BetterService : System.Web.Services.WebService
    {
        //Web service in içinde yeni bir metod oluştururken her zaman üstüne [WebMethod] ekleyin
        [WebMethod]
        public string HelloWorld()
        {
            return "Merhaba World";
        }
    }
}
