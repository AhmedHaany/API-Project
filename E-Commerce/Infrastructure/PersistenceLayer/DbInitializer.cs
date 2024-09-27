using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceLayer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly StoreContext _storeContext;

		public DbInitializer(StoreContext storeContext)
        {
			_storeContext = storeContext;
		}
        public async Task InitializeAsync()
		{
			try
			{
				if (_storeContext.Database.GetPendingMigrations().Any())
					await _storeContext.Database.MigrateAsync();

				if (!_storeContext.ProductTypes.Any())
				{
					// Read Types From File as string
					var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\PersistenceLayer\Data\Seeding\types.json");
					// Transfomr into C# Objects 

					var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

					// Add To DB & SaveChangess
					if (types is not null && types.Any())
					{
						await _storeContext.AddRangeAsync(types);
						await _storeContext.SaveChangesAsync();
					}
				}

				if (!_storeContext.ProductBrands.Any())
				{
					// Read Types From File as string
					var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\PersistenceLayer\Data\Seeding\brands.json");
					// Transfomr into C# Objects 

					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

					// Add To DB & SaveChangess
					if (brands is not null && brands.Any())
					{
						await _storeContext.AddRangeAsync(brands);
						await _storeContext.SaveChangesAsync();
					}
				}

				if (!_storeContext.Products.Any())
				{
					// Read Types From File as string
					var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\PersistenceLayer\Data\Seeding\products.json");
					// Transfomr into C# Objects 

					var products = JsonSerializer.Deserialize<List<Product>>(productsData);

					// Add To DB & SaveChangess
					if (products is not null && products.Any())
					{
						await _storeContext.AddRangeAsync(products);
						await _storeContext.SaveChangesAsync();
					}
				}
			}catch (Exception)
			{
				throw;
			}
		}
	}
}
//C:\Users\ahmed\Documents\Courses\Backend ASP.net\08 Asp.Net Web Apis\API Demo\E-Commerce\Infrastructure\PersistenceLayer\Data\Seeding\types.json