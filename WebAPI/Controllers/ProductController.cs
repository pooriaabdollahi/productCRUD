using Application;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       
        // GET: ProductController/Create
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpPost("Create")]
        public ActionResult Create(CreateProductModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateProductModel, ProductModel>());
            var mapper = config.CreateMapper();
            ProductModel productModel = mapper.Map<ProductModel>(product);
            productModel.Creator = "1";
             
            var result = _productRepository.Create(productModel);
            return new JsonResult(result);
        }
        [HttpGet("GetAll")]
        public ActionResult<List<ProductModel>> getAll()
        {
            var result = _productRepository.GetAll();
            return new JsonResult(result);
        }
        [HttpPost("Filter")]
        public ActionResult<List<ProductModel>> getbyFilter(ProductFilterModel filters)
        {
            var result = _productRepository.GetByFilter(filters);
            return new JsonResult(filters);
        }
        [HttpPost("Update")]
        public ActionResult<ProductModel> Update(ProductModel product)
        {
            var result =_productRepository.Update(product);
            return new JsonResult(result);
        }
        [HttpPost("Delete")]
        public ActionResult<ProductModel> Delete(ProductModel product)
        {
            var result = _productRepository.Delete(product);
            return new JsonResult(result);
        }
        // GET: ProductController/Edit/5
       
    }
}
