using SuperShop.Data.Entities;
using SuperShop.Models;
using System.IO;

namespace SuperShop.Helpers
{
	public class ConverterHelper : IConverterHelper
	{
		public Product ToProduct(ProductViewModel model, string path, bool isNew)
		{
			return new Product
			{
				Id = isNew  ? 0 : model.Id,
				ImageURL = path,
				IsAvailable = model.IsAvailable,
				LastPurchase = model.LastPurchase,
				LastSale = model.LastSale,
				Name = model.Name,
				Price = model.Price,
				Stock = model.Stock,
				User = model.User
			};
		}

		public Product ToProductViewModel(Product product)
		{
			return new ProductViewModel
			{
				Id = product.Id,
				IsAvailable = product.IsAvailable,
				LastPurchase = product.LastPurchase,
				LastSale = product.LastSale,
				ImageURL = product.ImageURL,
				Name = product.Name,
				Price = product.Price,
				Stock = product.Stock,
				User = product.User
			};
		}
	}
}
