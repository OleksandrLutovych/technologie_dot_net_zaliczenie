namespace Oleksandr_Lut_zal.Models
{
    public class ShopingPosition
    {
        public int id { get; set; }
        public string ownerId { get; set; }

        public string description { get; set; }
        public bool isDrawOut { get; set; }
        public int ShoopingListId { get; set; }
        public ShoppingPositionList ShoopingList { get; set; }
    }
}
