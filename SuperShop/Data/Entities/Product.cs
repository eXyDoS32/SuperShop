﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product : IEntity
    {
        //[Key] server para caso queria mudar o nome do Id 
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="The field {0} can only contain {1} characters length.")]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }


        [Display(Name ="Image")]
        public string ImageURL { get; set; }


        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }


        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }


        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Double Stock { get; set; }

        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageURL))
                {
                    return null;
                }

                return $"https://localhost:44320{ImageURL.Substring(1)}";
            }
        }
    }
}
