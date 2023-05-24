using System.ComponentModel.DataAnnotations;

namespace QRWebApp.Models
{
    public enum DateViewModel
    {

        [Display(Name = "Дни")]
        Days,
        [Display(Name = "Месяцы")]
        Months
    }
}
