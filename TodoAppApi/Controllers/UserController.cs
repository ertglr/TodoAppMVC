using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;
using TodoAppApi.Models;

namespace TodoAppApi.Controllers
{
    public class UserController : ApiController
    {
        TodoContext db = new TodoContext();



        public IHttpActionResult GetUsers()
        {
            try
            {
                List<UserVM> userVMs = new List<UserVM>();

                foreach (var item in db.Users.ToList())
                {

                    userVMs.Add(new UserVM() { ID = item.ID, Firstname = item.Firstname, Lastname = item.Lastname, Username = item.Username, Email = item.Email, ModifiedUser = item.ModifiedUser });
                }


                return Json(userVMs.ToList());
            }
            catch (Exception e)
            {

                return NotFound();
                throw e;
            }

        }




        public IHttpActionResult GetUserById(string username)
        {
            try
            {

                UserVM userVM = new UserVM();
                var user = db.Users.FirstOrDefault(i => i.Username == username);
                if (user == null)
                {
                    return NotFound();
                }
                userVM.ID = user.ID;
                userVM.Firstname = user.Firstname;
                userVM.Username = user.Username;
                userVM.Lastname = user.Lastname;
                userVM.Email = user.Email;
                return Json(userVM);
            }
            catch (Exception e)
            {
                return BadRequest();

                throw e;
            }
        }


        public IHttpActionResult PostUser(UserVM userVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User();
                    user.Firstname = userVm.Firstname;
                    user.Lastname = userVm.Lastname;
                    user.Username = userVm.Username;
                    user.ModifiedUser = userVm.ModifiedUser;
                    user.Email = userVm.Email;
                    user.CreatedOn = DateTime.Now;
                    user.Password = userVm.Password;
                    user.ConfirmPassword = userVm.ConfirmPassword;
                    db.Users.Add(user);
                    if (db.SaveChanges() > 0)
                    {
                        return GetUserById(user.Username);
                    }
                    return BadRequest();
                }


                return BadRequest();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IHttpActionResult DeleteUser(string username)
        {
            try
            {
                var user = db.Users.FirstOrDefault(i => i.Username == username);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return GetUsers();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
                throw e;
            }
        }

        public IHttpActionResult PutUser(UserVM user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedUser = db.Users.FirstOrDefault(i => i.Username == user.Username);
                if (updatedUser==null)
                {
                    return NotFound();
                }
                db.Entry(updatedUser).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return GetUserById(user.Username);
                }
                return BadRequest("Güncelleme işlemi başarısız oldu");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

    }
}
