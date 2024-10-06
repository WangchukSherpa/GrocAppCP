namespace ProjWork.Entities
{
    public class Product : BaseEntities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }//Fk
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
