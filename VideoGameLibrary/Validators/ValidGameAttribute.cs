using VideoGameLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoGameLibrary.Validators
{
    public class ValidGameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (Game)validationContext.ObjectInstance;
            if (game.Title == string.Empty || game.Title == null)
            { 
                return new ValidationResult("Game must have a title.");
            }
            if (game.Platform == string.Empty || game.Platform == null)
            {
                return new ValidationResult("Game must have a platform.");
            }
            if (game.Genere == string.Empty || game.Genere == null)
            {
                return new ValidationResult("Game must have a genere.");
            }
            if (game.ImageName == string.Empty || game.ImageName == null)
            {
                return new ValidationResult("Game must have an image");
            }
            if (game.ReleaseYear <= 1958 || game.ReleaseYear > 2023)
            {
                return new ValidationResult("No games were released in that year");
            }
            return ValidationResult.Success;
        }
    }
}
