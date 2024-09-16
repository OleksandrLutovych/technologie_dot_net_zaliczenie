namespace Oleksandr_Lut_zal.Models
{
    public class ShoppingPositionList
    {
        public int id { get; set; }
        public string listTitle { get; set; }

        public string ownerId { get; set; }
        public virtual ICollection<ShopingPosition> ShopingPosition { get; set; }

    }
}
