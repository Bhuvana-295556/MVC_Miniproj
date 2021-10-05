using api.Models;
using DailyBL;
using DailyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        
        public ActionResult ViewUser()

        {
            List<User> lstUser = new List<User>();
            UserBL blObj = new UserBL();
            var result = blObj.GetAllUser();
            foreach (var item in result)
            {
                lstUser.Add(new User()
                {
                    
                    FullName = item.FullName,
                    Email = item.Email


                });
            }

            return View(lstUser);
        }


        
        public ActionResult AddUser()
        {


            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult AddnewUser(User newuser)
        {
            try
            {
                UserBL blObj = new UserBL();
                UserDTO newDto = new UserDTO();
                // newdeptDto.DepartmentID = newdept.DepartmentID;
                newDto.FullName = newuser.FullName;
                newDto.Email = newuser.Email;
                int result = blObj.AddNewUser(newDto);
                if (result == 1)
                {
                    return RedirectToAction("ViewUser");
                }
                else
                {
                    return View("AddUser");
                }

            }
            catch (Exception)
            {


                return ViewBag("Error");
            }
        }


        }

}