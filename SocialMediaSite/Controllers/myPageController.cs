using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Dynamic;
using System.Security.Claims;

namespace SocialMediaSite.Controllers
{
    public class myPageController : Controller
    {
        IMyPageAccessLayer DAL;
        IImageAccessLayer DAL2;
        public myPageController(IMyPageAccessLayer dal, IImageAccessLayer dAL2)
        {
            DAL = dal;
            DAL2 = dAL2;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyPage()
        {
            MyPage page = DAL.GetMyPage(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (page != null)
            {
                ViewBag.Image = DAL2.GetImage(page.pictureID).imageName;
                return View(page);
            }
            else if (DAL2.GetImages(User.FindFirstValue(ClaimTypes.NameIdentifier)).Count() < 1)
            {
                return RedirectToAction("UploadPhoto", "Image");
            }
            else
            {
                return CreateMyPage();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateMyPage()
        {
            var images = DAL2.GetImages(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var viewModel = new MyPageImage(new MyPage(), new SelectList(images, "Id", "imageName"));
            return View("CreateMyPage", viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateMyPage(MyPageImage page) 
        {
            page.myPages.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (page.myPages.aboutMe.Contains("\r\n"))
            { 
                page.myPages.aboutMe = page.myPages.aboutMe.Replace("\r\n", "<br />");
            }
            DAL.CreatePage(page.myPages);
            return Redirect("MyPage");
        }
    }
}
