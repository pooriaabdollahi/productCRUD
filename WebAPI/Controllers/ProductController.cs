using Application;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
       
        // GET: ProductController/Create
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpPost("Create")]
        [Authorize]
        public ActionResult Create(CreateProductModel product)
        {
            
            var currentUser = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user");
            if (currentUser == null) {return Unauthorized();}
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateProductModel, ProductModel>());
            var mapper = config.CreateMapper();
            ProductModel productModel = mapper.Map<ProductModel>(product);
            productModel.Creator = currentUser.Value;
             
            var result = _productRepository.Create(productModel);
            return new JsonResult(result);
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public ActionResult<List<ProductModel>> getAll()
        {
            var result = _productRepository.GetAll();
            return new JsonResult(result);
        }
        [HttpPost("Filter")]
        [AllowAnonymous]
        public ActionResult<List<ProductModel>> getbyFilter(ProductFilterModel filters)
        {
            var result = _productRepository.GetByFilter(filters);
            return new JsonResult(filters);
        }
        [HttpPost("Update")]
        [Authorize]
        public ActionResult<ProductModel> Update(ProductModel product)
        {
            var currentUser = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user");
            if (currentUser?.Value != product.Creator)
            {
                return Unauthorized();
            }
            var result =_productRepository.Update(product);
            return new JsonResult(result);
        }
        [HttpPost("Delete")]
        [Authorize]
        public ActionResult<ProductModel> Delete(ProductModel product)
        {
            var currentUser = HttpContext.User.Claims.FirstOrDefault(x=>x.Type=="user");
            if (currentUser?.Value != product.Creator)
            {
                return Unauthorized();
            }
            var result = _productRepository.Delete(product);
            return new JsonResult(result);
        }
       
    }
}
