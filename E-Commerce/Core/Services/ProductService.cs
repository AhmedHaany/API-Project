using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;
using Services.Specifications;
using Shared;

namespace Services
{
	internal class ProductService(IUnitOfWork unitOfWork, IMapper  Mapper) : IProductService
	{
		public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
		{
			// 1. Retrieve All Brands => UnitOfWork
			var brands = await unitOfWork.GetGenericRepository<ProductBrand, int>().GetAllAsync();
			// 2. Map to Brand ResultTDO => Immaper
			var brandsResult = Mapper.Map<IEnumerable<BrandResultDTO>>(brands);
			return brandsResult;
		}

		public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync()
		{

			var products = await unitOfWork.GetGenericRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications());
			var ProductResult = Mapper.Map<IEnumerable<ProductResultDTO>>(products);
			return ProductResult;

		}

		public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
		{
			var types = await unitOfWork.GetGenericRepository<ProductType, int>().GetAllAsync();
			var TypesResult = Mapper.Map<IEnumerable<TypeResultDTO>>(types);
			return TypesResult;
		}

		public async Task<ProductResultDTO?> GetProductByIdAsync(int id)
		{
			var product = await unitOfWork.GetGenericRepository<Product,int>().GetAsync(new ProductWithBrandAndTypeSpecifications(id));
			var ProductResult = Mapper.Map<ProductResultDTO>(product);
			return ProductResult;
		}
	}
}
