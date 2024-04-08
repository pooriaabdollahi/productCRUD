using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.Models;
using Infrastructure;

namespace Infrastructure
{
    internal class ProductRepository : IProductRepository
    {
        private MyDBContext _dboContext { get; set; }

        public ProductRepository(MyDBContext dbo)
        {
            _dboContext = dbo ?? throw new ArgumentNullException(nameof(ProductRepository));
        }

        public ProductModel? Create(ProductModel product)
        {

            try
            {
                _dboContext.Add(product);

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProductModel? Delete(ProductModel product)
        {
            try
            {
                _dboContext.Remove(product);

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProductModel>? GetAll()
        {
            return _dboContext.Products?.ToList();
        }

        public List<ProductModel>? GetByFilter(ProductFilterModel filters)
        {
            var products = _dboContext.Products.Where(p => applyFilter(filters,p)).ToList();
            return products;
        }
        private bool applyFilter(ProductFilterModel filters,ProductModel product)
        {
            if (filters == null)
                return true;
            else if ((filters.Name != null) && (filters.Name != product.Name)) 
                return false;
            else if ((filters.ProduceDateFrom != null) && (filters.ProduceDateFrom > product.ProduceDate)) 
                return false;
            else if ((filters.ProduceDateTo != null) && (filters.ProduceDateTo < product.ProduceDate)) 
                return false;
            else if ((filters.ManufactureEmail != null) && (filters.ManufactureEmail != product.ManufactureEmail)) 
                return false;
            else if ((filters.ManufacturePhone != null) && (filters.ManufacturePhone != product.ManufacturePhone)) 
                return false;
            else if ((filters.Name != null) && (filters.Name != product.Name))
                return false;
            return true;
        }
        public ProductModel? Update(ProductModel product)
        {
            try
            {
                _dboContext.Update(product);

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
