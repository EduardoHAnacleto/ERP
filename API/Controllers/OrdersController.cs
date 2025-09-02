using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : BaseController<Order, OrderDto>
    {
        public OrdersController(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper) { }
    }
}
