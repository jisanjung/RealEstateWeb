using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;

namespace Utilities
{
    public static class RestClient
    {
        public static string Get(string url)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse(); // wait

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }

        public static string Post(string url, string jsonStr)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = jsonStr.Length;
            request.ContentType = "application/json";

            // Write the JSON data to the Web Request
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonStr);
            writer.Flush();
            writer.Close();

            // Read the data from the Web Response, which requires working with streams.
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }
        public static string Put(string url, string jsonStr)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentLength = jsonStr.Length;
            request.ContentType = "application/json";

            // Write the JSON data to the Web Request
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonStr);
            writer.Flush();
            writer.Close();

            // Read the data from the Web Response, which requires working with streams.
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }

        public static string Delete(string url)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(url);
            request.Method = "DELETE";
            WebResponse response = request.GetResponse(); // wait

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }
    }
}
