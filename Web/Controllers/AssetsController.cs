using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities.Business;
using AspNetLayeredArchitectureWithDapper.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetLayeredArchitectureWithDapper.Web.Controllers
{
    public class AssetsController : AspNetLayeredArchitectureWithDapperBase
    {
        private readonly IBusinessServiceBase<Assets> _assetsService;
        private readonly IMapper _mapper;
        public AssetsController(
            IBusinessServiceBase<Assets> AssetsService,
            IMapper Mapper
            )
        {
            _assetsService = AssetsService;
            _mapper = Mapper;
        }
        public IActionResult Index()
        {
            var AssetsResult = _assetsService.GetList();

            var ViewModelData = _mapper.Map<PageViewModel<IEnumerable<AssetsViewModel>>>(AssetsResult);

            return View(ViewModelData);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_AddModelPartial", new AssetsViewModel());
        }
        [HttpPost]
        public IActionResult Add(AssetsViewModel asset)
        {
            var AssetData = _mapper.Map<Assets>(asset);
            var result = _assetsService.Add(AssetData);
            return PartialView("_AddModelPartial", asset);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var ServiceResult = _assetsService.Get(Id);
            var AssetViewData = _mapper.Map<AssetsViewModel>(ServiceResult.Data);
            return PartialView("_EditModelPartial", AssetViewData);
        }
        [HttpPost]
        public IActionResult Edit(AssetsViewModel asset)
        {
            var AssetData = _mapper.Map<Assets>(asset);
            _assetsService.Update(AssetData);
            return PartialView("_EditModelPartial", asset);
        }
    }
}