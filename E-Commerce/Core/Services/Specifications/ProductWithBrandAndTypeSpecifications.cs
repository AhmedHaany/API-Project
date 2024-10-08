using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
	internal class ProductWithBrandAndTypeSpecifications :Specifications<Product>
	{
		public ProductWithBrandAndTypeSpecifications(int id):base(product=> product.Id==id )
		{
			AddInclude(product=>product.ProductBrand);
			AddInclude(product=>product.ProductType);
		}

		public ProductWithBrandAndTypeSpecifications() : base(null)
		{
			AddInclude(product => product.ProductBrand);
			AddInclude(product => product.ProductType);
		}


	}
}
