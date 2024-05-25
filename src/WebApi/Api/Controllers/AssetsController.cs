using Core.Abstracts;
using Core.Attributes.Authorize;
using Core.Entities.Results;
using Core.Services.Abstracts;
using Entities.Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiAuthorize]
    public class AssetsController : BaseApiController
    {
        private readonly LayerAbstractBase<Assets> _assetsService;
        private readonly ILogger<AssetsController> logger;
        public AssetsController(
            LayerAbstractBase<Assets> AssetsService,
            ILogger<AssetsController> Logger
            )
        {
            _assetsService = AssetsService;
            logger = Logger;
        }
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultBase(false, "Metot istek modeli hatalı, kontrol ediniz."));
            }
            var AssetList = await _assetsService.GetListAsync();
            if (AssetList.Success && AssetList.Data != null)
            {
                return Ok(AssetList);
            }
            return NotFound(AssetList);
        }
    }
}
