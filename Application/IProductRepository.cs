using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IProductRepository
    {
        public ProductModel? Create(ProductModel product);
        public ProductModel? Update(ProductModel product);
        public ProductModel? Delete(ProductModel product);
        public List<ProductModel>? GetByFilter(ProductFilterModel filters);
        public List<ProductModel>? GetAll();
    }
}
