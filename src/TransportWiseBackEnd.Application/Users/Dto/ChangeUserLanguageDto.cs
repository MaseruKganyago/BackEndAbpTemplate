using System.ComponentModel.DataAnnotations;

namespace TransportWiseBackEnd.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}