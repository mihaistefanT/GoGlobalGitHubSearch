using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GoGlobalGitHubSearch.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly ILogger<BookmarkController> _logger;

        public BookmarkController(ILogger<BookmarkController> logger)
        {
            _logger = logger;
        }

        //here another post was needed to serve the bookmarks 

        //another post was needed here to export the bookmarks to csv/xls

        // the methods Export/import could have been extracted into an Inteface (IConversions let's say)
        // after that a class what implements the cvs implimentation would have been added
        // after that a class what implements the xls implimentation would have been added
    }
}