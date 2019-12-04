using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
namespace EjemploConsumoAPi
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www-prueba.titanio.com.co/PDE/public/api/auth/signin");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.UseDefaultCredentials = true;
            httpWebRequest.PreAuthenticate = true;

            DTOAutenticacion auth = new DTOAutenticacion()
            {
                NIT = "900103987",
                usuario = "PHIPACKLTDA",
                password = "qszLXoCo"
            };
            using (var streamWriter = new

            StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(auth);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.Write(result);
            }

        }
    }
}
