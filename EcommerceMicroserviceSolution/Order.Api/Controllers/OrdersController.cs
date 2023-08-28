using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.ApiModel;
using Order.Application.Interface;
using Order.Domain;
using System.Net;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService) 
        { 
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult GetProducts()
        {
            ApiResult<Orders> response = new ApiResult<Orders>();
            try
            {
                List<Orders> orders = _orderService.GetOrders();
                if (orders != null && orders.Count>0)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    response.data = orders;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No Data";
                    response.status = "99";
                    response.success = false;
                    response.data = new List<Orders>();
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
        [HttpGet("{orderId:int}")]
        public async Task<ActionResult> GetById(int orderId)
        {
            ApiResult<Orders> response = new ApiResult<Orders>();
            try
            {
                Orders orders = await _orderService.GetOrderById(orderId);
                if(orders != null && orders.Id > 0)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    response.data.Add(orders);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "Internal server error";
                    response.status = "99";
                    response.success = false;
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
        public async Task<ActionResult> Create(Orders orders)
        {
            ApiResult<string> response = new ApiResult<string>();
            try
            {
                var success = await _orderService.CreateOrder(orders);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "Internal server error";
                    response.status = "99";
                    response.success = false;
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
        [HttpPut]
        public async Task<ActionResult> Update(Orders orders)
        {
            ApiResult<string> response = new ApiResult<string>();
            try
            {
                var success = await _orderService.UpdateOrder(orders);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "Internal server error";
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
        [HttpDelete("{orderId:int}")]
        public async Task<ActionResult> Delete(int orderId)
        {
            ApiResult<string> response = new ApiResult<string>();
            try
            {
                var success = await _orderService.DeleteOrderById(orderId);
                if (success)
                {
                    response.message = "Operation Successful";
                    response.status = "00";
                    response.success = true;
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "Internal server error";
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
