using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
	internal class ProductWithBrandAndSpecifications :Specifications<Product>
	{
		public ProductWithBrandAndSpecifications(int id):base(product=> product.Id==id )
		{
			AddInclude(product=>product.ProductBrand);
			AddInclude(product=>product.ProductType);
		}

		public ProductWithBrandAndSpecifications() : base(null)
		{
			AddInclude(product => product.ProductBrand);
			AddInclude(product => product.ProductType);
		}


	}
}
