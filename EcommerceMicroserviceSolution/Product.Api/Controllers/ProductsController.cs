using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.ApiModel;
using Product.Application.Interface;
using Product.Application.Repository;
using Product.Domain;
using System.Net;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult GetProducts()
        {
            ApiResult<Products> response = new ApiResult<Products>();
            try
            {
                List<Products> products = _productService.GetProducts();
                if (products != null && products.Count > 0)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    response.data = products;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    response.data = new List<Products>();
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                response.message = "Internal server error: " + ex.Message.ToString();
                response.status = "99";
                response.success = false;
                return StatusCode((int)HttpStatusCode.OK, response);
            }
        }
        [HttpGet("{productid:int}")]
        public async Task<ActionResult> GetById(int productId)
        {
            ApiResult<Products> response = new ApiResult<Products>();
            try
            {
                Products products = await _productService.GetProductById(productId);
                if(products!= null && products.Id> 0)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    response.data.Add(products);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    response.data = new List<Products>();
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            catch(Exception ex)
            {
                response.message = "Internal server error: " + ex.Message.ToString();
                response.status = "99";
                response.success = false;
                return StatusCode((int)HttpStatusCode.OK, response);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Products products)
        {
            ApiResult<Products> response = new ApiResult<Products>();
            try
            {
                bool success = await _productService.CreateProduct(products);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                response.message = "Internal server error: " + ex.Message.ToString();
                response.status = "99";
                response.success = false;
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            
        }
        [HttpPut]
        public async Task<ActionResult> Update(Products products) 
        {

            ApiResult<Products> response = new ApiResult<Products>();
            try
            {
                bool success = await _productService.UpdateProduct(products);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                response.message = "Internal server error: " + ex.Message.ToString();
                response.status = "99";
                response.success = false;
                return StatusCode((int)HttpStatusCode.OK, response);
            }
             
        }
        [HttpDelete("{productid:int}")]
        public async Task<ActionResult> Delete(int productid)
        {
            ApiResult<Products> response = new ApiResult<Products>();
            try
            {
                bool success = await _productService.DeleteProductById(productid);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                response.message = "Internal server error: " + ex.Message.ToString();
                response.status = "99";
                response.success = false;
                return StatusCode((int)HttpStatusCode.OK, response);
            }
        }
    }
}
