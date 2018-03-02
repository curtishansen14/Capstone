using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using CapStone.Models;
using Microsoft.AspNet.Identity;


namespace CapStone.APICalls
{
    public static class SendGridCall
    {
        public static void SendMail(string destinationEmail,  string subject, string message, string callbackURL)
        {
            var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "1686da26-b413-fc2a-ea12-994820935a93");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer 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");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n  \"personalizations\": [\n    {\n      \"to\": [\n        {\n          \"email\": \""+destinationEmail+"\",\n          \"name\": \"John Doe\"\n        }\n      ],\n      \"subject\": \"Hello, World!\"\n    }\n  ],\n  \"from\": {\n    \"email\": \"HortioDevCode@gmail.com\",\n    \"name\": \"Horatio\"\n  },\n  \"subject\": \"Welcome!\",\n  \"content\": [\n    {\n      \"type\": \"text/html\",\n      \"value\": \"<html>" + callbackURL + "</html>\"\n    }\n  ]\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }

   
    
}