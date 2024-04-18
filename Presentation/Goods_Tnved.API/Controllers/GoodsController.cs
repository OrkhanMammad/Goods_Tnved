using Goods_Tnved.Application.Repositories.GoodRepos;
using Goods_Tnved.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goods_Tnved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        readonly IGoodReadRepository _goodReadRepository;

        public GoodsController(IGoodReadRepository goodReadRepository)
        {
            _goodReadRepository= goodReadRepository;
        }
        [HttpGet]
        [Route("GetGoodByCode")]
        public async Task<Good> GetGoodByCode(string goodCode)
        {
           return await _goodReadRepository.GetGoodAsync(goodCode);
        }

    }
}
