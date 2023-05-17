using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product
    {
        //[Key] server para caso queria mudar o nome do Id 
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }

        [Display(Name ="Image")]
        public string ImageURL { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Double Stock { get; set; }
    }
}
