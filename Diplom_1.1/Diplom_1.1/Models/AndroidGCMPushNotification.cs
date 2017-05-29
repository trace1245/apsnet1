using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;
using Diplom.Models;
using Diplom_1._1.ViewModels;
using System.Web.Mvc;

public class AndroidGCMPushNotification
{
    public AndroidGCMPushNotification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private static void SendPushNotification(string deviceId, string message)
    {

        try
        {

            string applicationID = "AAAA_H8iFOs:APA91bEpcCvgnPRqg84BdBfchUDHeQBiZ1dOp-C1R1PdidszPJritLgrpS7a7Gh5MEfkLqp6E9rXTsppgKLbL63uPM4vt9DxhjZtMKAmEix8i_X3RT9XQ0Qyj2jFmR2wOOP4KeOXP1V3";

            string senderId = "1084464698603";


            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = deviceId,
                notification = new
                {
                    body = message,
                    title = "Notification",
                    sound = "Enabled"
                    
                }
            };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            using(Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using(WebResponse tResponse = tRequest.GetResponse())
                {
                    using(Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using(StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            string str = sResponseFromServer;
                        }
                    }
                }
            }
        }
        catch(Exception ex)
        {
            string str = ex.Message;
        }
    }
    public static void SendNotification(MyContext db, CommentViewModel model)
    {
        string ChosenGroup = "";
        SelectList ListGroups = new SelectList(db.Groups, "Id", "Name");
        foreach(SelectListItem i in ListGroups)
        {
            if(i.Value == model.ChosenGroup)
            {
                ChosenGroup = i.Text;
            }

        }

        if(model.Who == "1" && ChosenGroup == "") // to all students
        {
            foreach(ClientId client in db.Clients)
            {
                if(!client.IsProf)
                {
                    SendPushNotification(client.PhoneId, model.Message);
                }
            }
        }

        if(model.Who == "1" && ChosenGroup != "") // to some students
        {
            foreach(ClientId client in db.Clients)
            {
                if(!client.IsProf && client.Group == ChosenGroup)
                {
                    SendPushNotification(client.PhoneId, model.Message);
                }
            }
        }

        if(model.Who == "2") // to all lectors
        {
            foreach(ClientId client in db.Clients)
            {
                if(client.IsProf)
                {
                    SendPushNotification(client.PhoneId, model.Message);
                }
            }
        }

        if(model.Who == "3") // to everyone
        {
            foreach(ClientId client in db.Clients)
            {
                    SendPushNotification(client.PhoneId, model.Message);
            }
        }
    }
}