using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace GoGlobalGitHubSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchResultController : ControllerBase
    {
        
        private readonly ILogger<SearchResultController> _logger;

        public SearchResultController(ILogger<SearchResultController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("search")]
        public List<SearchResult> Post([FromBody] GITQuery query)
        {
            const string URL = "https://api.github.com/search/repositories";
            var urlParameters = $"?q={query.Query}";

            var root = new Rootobject();
            var searchResultList = new List<SearchResult>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using (HttpResponseMessage response = client.GetAsync(urlParameters).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                         root = response.Content.ReadAsAsync<Rootobject>().Result;
                    }
                }
            }

            if (root != null)
            {
                var i = 0;
                foreach (var item in root.items)
                {
                    var searchResult = new SearchResult
                    {
                        RepoName = item.full_name,
                        Avatar = item.owner.avatar_url,
                        Description = item.description
                    };
                    searchResultList.Add(searchResult);
                }
            }
            return searchResultList;
        }
        
        [HttpPost("sendEmail")]
        public bool SendEmail([FromBody] GITEmail email)
        {
            //this does not send the email because Google changed its policy and you cant send emails from new apps at the moment 
            //but this is the base of how you use a SMTP to send emails
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("goglobalfeelit@gmail.com");
                mail.To.Add(email.Email);
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("goglobalfeelit@gmail.com", "SAH2gkPrxmexAg7");
                    smtp.EnableSsl = true;
                    //smtp.Send(mail);
                    return true;
                }
            }
        }
    }
}
