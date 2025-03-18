using Blazor_Custom_Auth.Application.Interfaces;
using Blazor_Custom_Auth.Domain.Entities;
using Blazor_Custom_Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Custom_Auth.Infrastructure.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
             _context=context;
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);  
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var prdtoDelete= await _context.Products.FindAsync(id);
            if (prdtoDelete != null)
            {
                _context.Products.Remove(prdtoDelete);
               await _context.SaveChangesAsync();

            }


        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productByID = await _context.Products.FindAsync(id);
            return productByID;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           var allPrd= await _context.Products.ToListAsync();
            return allPrd;
        }

        public Task UpdateProductAsync(Product product)
        {
           var prdtoUpd=_context.Products.FindAsync(product.Id);
            if (prdtoUpd != null)
            {
                prdtoUpd.Result.Name = product.Name;
                prdtoUpd.Result.CreatedAt = product.CreatedAt;
                prdtoUpd.Result.Description = product.Description;
            }
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
