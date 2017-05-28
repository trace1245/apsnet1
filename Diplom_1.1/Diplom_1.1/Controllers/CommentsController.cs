using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom_1._1.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public string Index()
        {
            AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
            do
            {
                AndroidGCMPushNotification.SendPushNotification();
            } while(true);
            
            return "adasd";
        }
    }
}