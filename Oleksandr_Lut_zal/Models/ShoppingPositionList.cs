
using System.ComponentModel.DataAnnotations;

namespace Oleksandr_Lut_zal.Models
{
    public class ShoppingPositionList
    {
        public int id { get; set; }
        public string listTitle { get; set; }

        public string ownerId { get; set; }
        public virtual ICollection<ShopingPosition> ShopingPosition { get; set; }

        [Required(ErrorMessage = "Musisz wybrać datę")]
        [DataType(DataType.Date)]
        [Display(Name = "Planned Shopping Date")]
        [CustomValidation(typeof(ShoppingPositionList), nameof(ValidateDate))]
        public DateTime PlannedDate { get; set; }
        public static ValidationResult ValidateDate(DateTime plannedDate, ValidationContext context)
        {
            if (plannedDate.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Zaplanowana data nie może być przeszła");
            }

            return ValidationResult.Success;
        }

    }
}
