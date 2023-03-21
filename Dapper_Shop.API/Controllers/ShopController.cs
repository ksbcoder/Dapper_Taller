using AutoMapper;
using Dapper_Shop.Domain.Commands;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopUseCase _shopUseCase;
        private readonly IMapper _mapper;

        public ShopController(IShopUseCase shopUseCase, IMapper mapper)
        {
            _shopUseCase = shopUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Shop>> GetShops()
        {
            return await _shopUseCase.GetShops();
        }

        [HttpPost]
        public async Task<Shop> CreateShop([FromBody] NewShop newShop)
        {
            return await _shopUseCase.CreateShop(_mapper.Map<Shop>(newShop));
        }
    }
}
