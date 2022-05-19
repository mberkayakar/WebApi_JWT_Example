using Business.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApi.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class Controller:ControllerBase
    {

        #region DB den direk çekmek için Newleme Constructor ü ve action u 

        //private readonly MyDbContext _dbContext;

        //public Controller(MyDbContext db)
        //{
        //    _dbContext = db;

        //}

        //[HttpGet]
        //public IActionResult deneme()
        //{

        //    var model = _dbContext.Products.ToList();
        //    return Ok(model);
        //}
        #endregion



        private  IProductService _productService;
        public Controller(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var model = _productService.GetAll(x=> x.UnitPrice> 5).ToList();


            return Ok(model);
                 
        }

       
    }
}
