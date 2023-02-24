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
            else
            {
                return View("CreateMyPage");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateMyPage()
        {
            var images = DAL2.GetImages(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var viewModel = new MyPageImage(new MyPage(), new SelectList(images, "Id", "imageName"));
            return View(viewModel);
        }
    }
}
