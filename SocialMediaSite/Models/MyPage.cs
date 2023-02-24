using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
    public class MyPage
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string userID { get; set; }
        public int? pictureID { get; set; }
        public string? aboutMe { get; set; }

        public MyPage() { }

        public MyPage(string userID, int? pictureID, string? aboutMe)
        {
            this.userID = userID;
            this.pictureID = pictureID;
            this.aboutMe = aboutMe;
        }
    }
}
