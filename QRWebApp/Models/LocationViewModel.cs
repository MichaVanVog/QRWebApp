using System.ComponentModel.DataAnnotations;

namespace QRWebApp.Models
{
    public enum LocationViewModel
    {

        [Display(Name = "Котельники")]
        Kotelniki,
        [Display(Name = "Путилково")]
        Putilkovo,
        [Display(Name = "Дрожжино")]
        Drosschino
    }
}
