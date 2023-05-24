using System.ComponentModel.DataAnnotations;

namespace QR.Db.Models
{
    public enum Location
    {

        [Display(Name = "Котельники")]
        Kotelniki,
        [Display(Name = "Путилково")]
        Putilkovo,
        [Display(Name = "Дрожжино")]
        Drosschino
    }
}
