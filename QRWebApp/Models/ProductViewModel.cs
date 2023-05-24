using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace QRWebApp.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Не указано наименование")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана дата производства или срока годности")]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpireDate { get; set; }

        [Required(ErrorMessage = "Не выбран магазин")]
        [Display(Name = "Магазин")]
        public LocationViewModel Location { get; set; }

        [Display(Name = "Количество")]
        public int TermDays { get; set; }

        [Required(ErrorMessage = "Не выбран магазин")]
        [Display(Name = "Дни/Месяцы")]
        public DateViewModel DaysMonths { get; set; }
    }
}
