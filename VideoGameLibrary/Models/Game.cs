using System.Security.Cryptography.X509Certificates;

namespace VideoGameLibrary.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        public string? Title { get; set; } = "[NO TITLE]";
        public string? Platform { get; set; } = string.Empty;
        public string? Genere { get; set; } = string.Empty;
        public string? ESRB { get; set; } = "RP";
        public int ReleaseYear { get; set; } = 1958;
        public string? ImageName { get; set; } = string.Empty;
        public string? LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } = null;

        public Game() { }

        public Game(string Title, string Platform, string Genere, string ESRB, int ReleaseYear, string ImageName)
        { 
            this.Title = Title;
            this.Platform = Platform;
            this.Genere = Genere;
            this.ESRB = ESRB;
            this.ReleaseYear = ReleaseYear;
            this.ImageName = ImageName;
        }

        public Game(string Title, string Platform, string Genere, string ESRB, int ReleaseYear, string ImageName, string LoanedTo, DateTime LoanDate)
        {
            this.Title = Title;
            this.Platform = Platform;
            this.Genere = Genere;
            this.ESRB = ESRB;
            this.ReleaseYear = ReleaseYear;
            this.ImageName = ImageName;
            this.LoanedTo = LoanedTo;
            this.LoanDate = LoanDate;
        }

        public void Loan(string? name = null)
        {
            if (name != null)
            { 
                LoanedTo = name;
                LoanDate = DateTime.Now;
            }
            else if(LoanedTo != null) 
            {
                LoanedTo = null;
                LoanDate = null;
            }
        }
    }
}
