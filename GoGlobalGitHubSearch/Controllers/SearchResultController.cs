using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

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

        [HttpPost]
        public List<SearchResult> Post([FromBody] GITQuery query)
        {
            const string URL = "https://api.github.com/search/repositories";
            var urlParameters = $"?q={query.Query}";

            var root = new Rootobject();
            var SearchResultList = new List<SearchResult>();
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
                    else
                    {
                        //throw/log error
                        //Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
                    }
                }
            }

            if (root != null)
            {
                
                foreach (var item in root.items)
                {
                    var searchResult = new SearchResult
                    {
                        RepoName = item.full_name,
                        Avatar = item.owner.avatar_url,
                        Description = item.description
                    };
                    SearchResultList.Add(searchResult);
                }
            }

            return SearchResultList;
        }
    }
}
