﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetPhlixDB.Web.Controllers
{
    public class PeopleController : Controller
    {
        [Authorize]
        public IActionResult Details(string id)
        {
            return View();
        }
    }
}