using Microsoft.AspNetCore.Mvc.Rendering;

namespace SocialMediaSite.Models
{
    public class MyPageImage
    {
        public MyPage myPages { get; set; }
        public SelectList Images { get; set; }

        public MyPageImage() { }

        public MyPageImage(MyPage myPages, SelectList Images) 
        { 
            this.myPages = myPages;
            this.Images = Images;
        }
    }
}
