using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLayeredArchitectureWithDapper.Web.Controllers
{
    public class ContactController : AspNetLayeredArchitectureWithDapperBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}