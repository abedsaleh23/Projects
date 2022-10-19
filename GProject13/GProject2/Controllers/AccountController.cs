using GProject2.Areas.Identity.Data;
using GProject2.Data;
using GProject2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace GProject2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult ProfilePage()
        {
            return View();
        }
    }
}
