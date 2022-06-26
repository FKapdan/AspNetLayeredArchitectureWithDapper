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
            return PartialView("_AddModelPartial", new Assets());
        }
        [HttpPost]
        public IActionResult Add(Assets asset)
        {
            return PartialView("_AddModelPartial", new Assets());
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return PartialView("_EditModelPartial", _assetsService.GetList().Data.First());
        }
        [HttpPost]
        public IActionResult Edit(Assets asset)
        {
            return PartialView("_EditModelPartial", asset);
        }
    }
}