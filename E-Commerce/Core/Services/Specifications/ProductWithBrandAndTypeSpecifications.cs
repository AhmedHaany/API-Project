using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
	internal class ProductWithBrandAndTypeSpecifications : Specifications<Product>
	{
		public ProductWithBrandAndTypeSpecifications(int id)
			: base(product => product.Id == id)
		{
			AddInclude(product => product.ProductBrand);
			AddInclude(product => product.ProductType);
		}

		public ProductWithBrandAndTypeSpecifications(string? sort, int? brandId, int? TypeId)
			: base(product => (!brandId.HasValue || product.BrandId==brandId.Value) &&
					          (!TypeId.HasValue || product.TypeId == TypeId.Value))
		{
			AddInclude(product => product.ProductBrand);
			AddInclude(product => product.ProductType);

			if (!string.IsNullOrEmpty(sort))
			{
				switch (sort.ToLower().Trim())
				{
					case "pricedesc":
						SetOrderByDescending(p=>p.Price);
						break;

					case "priceasc":
						SetOrderBy(p => p.Price);
						break;

					case "nameddesc":
						SetOrderByDescending(p => p.Name);
						break;


					default:
						SetOrderBy(p=>p.Name);
						break;

				}
			}


		}
	}
}
