using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestStore.Application.Commands;
using TestStore.Application.Commands.ViewModels;
using TestStore.Application.Queries;
using TestStore.Application.ViewModels;

namespace TestStore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger,
                               IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetOrder")]
        public Task<OrderViewModel> GetOrder(string currency = "USD")
        {
            var order = _mediator.Send(new GetOrderQuery(currency));

            return order;
        }

        [HttpGet]
        [Route("ConvertItemPrice")]
        public Task<OrderViewModel> ConvertItemPrice(int productId, string currency = "USD")
        {
            var order = _mediator.Send(new GetConvertedItemQuery(productId, currency));

            return order;
        }

        [HttpPost]
        [Route("AddItem")]
        public Task AddItem(AddOrUpdateOrderItemViewModel item)
        {
            var order = _mediator.Send(new AddOrderItemCommand(item.ProductId, item.Quantity));

            return order;
        }

        [HttpPut]
        [Route("UpdateItem")]
        public Task UpdateItem(AddOrUpdateOrderItemViewModel item)
        {
            var order = _mediator.Send(new UpdateOrderItemCommand(item.ProductId, item.Quantity));

            return order;
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public Task DeleteItem(int productId)
        {
            var order = _mediator.Send(new DeleteOrderItemCommand(productId));

            return order;
        }
    }
}