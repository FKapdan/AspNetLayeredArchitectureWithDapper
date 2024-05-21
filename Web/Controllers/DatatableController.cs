using Web.Models;
using Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class DatatableController : AspNetLayeredArchitectureWithDapperBase
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetUserList()
        {
            DatatableViewModel<UserModel> ViewResult = new DatatableViewModel<UserModel>(
                GetModelDisplayNames<UserModel>(),
                new List<UserModel>(),
                true
            );
            #region Data Setion
            try
            {
                ViewResult.Data.Add(new UserModel()
                {
                    Id = 1,
                    Name = "CaptainName",
                    Surname = "CaptainSurName",
                    TelNo = "3213212121",
                    Job = "Computer Engineer",
                    Adress = "Where To Live",
                }
                );
                ViewResult.Data.Add(new UserModel()
                {
                    Id = 1,
                    Name = "CaptainName1",
                    Surname = "CaptainSurName1",
                    TelNo = "4324323232",
                    Job = "Software Engineer",
                    Adress = "Where To Live",
                }
                );
                ViewResult.Data.Add(new UserModel()
                {
                    Id = 1,
                    Name = "CaptainName2",
                    Surname = "CaptainSurName2",
                    TelNo = "5435434343",
                    Job = "DBA",
                    Adress = "Where To Live",
                }
                );
            }
            catch (Exception ex)
            {
                ViewResult.Error = ex.ToString();

            }
            #endregion
            return Json(ViewResult);
        }
    }
}