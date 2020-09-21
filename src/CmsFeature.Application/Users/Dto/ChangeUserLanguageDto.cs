using System.ComponentModel.DataAnnotations;

namespace CmsFeature.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}