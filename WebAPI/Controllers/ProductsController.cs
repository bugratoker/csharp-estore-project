using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController] // attribute 
    public class ProductsController : ControllerBase
    {

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //IoC Container Inversion of Control -- Değişimin kontrolü
        [HttpGet]
        public IActionResult Get()
        {
            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public ActionResult Add(Product product)
        {


            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        
    }
}
