using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Data;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Security.Claims;

namespace SocialMediaSite.Controllers
{
    public class ImageController : Controller
    {
        IImageAccessLayer DAL;
        public ImageController(IImageAccessLayer dAL)
        {
            DAL = dAL;
        }

        [Authorize]
        [HttpGet]
        public IActionResult UploadPhoto()
        {
            //return Content("owo");
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UploadPhoto(Images image)
        {
            image.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DAL.AddImage(image);
            if (ModelState.IsValid)
            {
                //return View("MyPage");
            }
            return View();
            //return Content("owo");
        }
    }
}
