using Blazor_Custom_Auth.Application.Interfaces;
using Blazor_Custom_Auth.Application.Services.IServices;
using Blazor_Custom_Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_Custom_Auth.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                await _productRepository.AddProductAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting product by id: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await _productRepository.GetProductsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting products: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                await _productRepository.UpdateProductAsync(product);
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Error updating product: {ex.Message}");
                throw;
            }
        }
    }
}

