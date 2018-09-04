using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepository _userRepository = new UserRepository();


        // GET api/images    
        [Route("api/Images")]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetUsers();
        }

        [HttpPost]
        [Route("api/Image")]

        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            postedFile.SaveAs(filePath);

            ////Save to DB
            //using (DBModel db = new DBModel())
            //{
            User user = new User()
            {
                FirstName = httpRequest["FirstName"],
                LastName = httpRequest["LastName"],
                Gender = httpRequest["Gender"],
                DateOfBirth = httpRequest["DateOfBirth"],
               

                ImageName = imageName
            };
            //    db.Users.Add(image);
            //    db.SaveChanges();
            //}

            if (_userRepository.AddUser(user))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }


}

