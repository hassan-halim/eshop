using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Interfaces;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Controllers.Api.ShoppingCart
{
    [Produces("application/json")]
    [Route("api/cart")]
    public class ShoppingCartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShoppingCartController
                (ICartRepository cartRepository, 
                 IUnitOfWork unitOfWork,
                 IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var cart = await cartRepository.CreateAsync();
            await unitOfWork.CompleteAsync();
            var result = mapper.Map<Cart, CartResource>(cart);
            return Ok(result);
        }
    }
}
