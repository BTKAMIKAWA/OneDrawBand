using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OneDraw.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;


namespace OneDraw.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("enter")]
        [HttpGet]
        public IActionResult Enter()
        {
            return RedirectToAction("Home");
        }

        [Route("discography")]
        [HttpGet]
        public IActionResult Discography()
        {
            return View();
        }
        
        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("send")]
        [HttpPost]
        public IActionResult Send(Email newemail)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("onedrawlb@gmail.com");
                MailAddress address = new MailAddress("onedrawlb@gmail.com");
                msg.From = address;

                msg.Subject = newemail.name + " : " + newemail.email;
                msg.Body = newemail.comments;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;

                NetworkCredential credentials = new NetworkCredential("onedrawlb@gmail.com", "LordsPrayer");
                client.Credentials = credentials;
                client.Send(msg);
                // lblResult.Text = "Your message was sent.";

                newemail.name = "";
                newemail.comments = "";
                newemail.email = "";

                return RedirectToAction("Contact");
            }
            catch
            {
                // lblResult.Text = "Your message failed to send, please try again.";
                return View("Contact");
            }
            
        }
        [Route("merchandise")]
        [HttpGet]
        public IActionResult Merchandise()
        {
            
            return View();
            
        }
        [Route("checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        
        }
    }
}
