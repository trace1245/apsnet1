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

public class AndroidGCMPushNotification
{
    public AndroidGCMPushNotification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void SendPushNotification()
    {

        try
        {

            string applicationID = "AAAA_H8iFOs:APA91bEpcCvgnPRqg84BdBfchUDHeQBiZ1dOp-C1R1PdidszPJritLgrpS7a7Gh5MEfkLqp6E9rXTsppgKLbL63uPM4vt9DxhjZtMKAmEix8i_X3RT9XQ0Qyj2jFmR2wOOP4KeOXP1V3";

            string senderId = "1084464698603";

            string deviceId = "fK9YkBd8aAI:APA91bF8qLf9YK8QaLdx-igGS8YA2cbHbffA2KdlfKW52O4nXcTMJ6Un8x7U7_VFbYINO2uGXnUgww41GF8-EcShROfuK-dougL2zlzPqKFcRT7286UVSH4rdr_Ol2OwLbHilsvN_h8i";

            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = deviceId,
                notification = new
                {
                    body = "VitalikLalka",
                    title = "AlBaami",
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
}