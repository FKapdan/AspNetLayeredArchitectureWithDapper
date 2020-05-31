using Microsoft.AspNetCore.Mvc;
using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities;

namespace AspNetLayeredArchitectureWithDapper.Web.Controllers
{
    public class AspNetLayeredArchitectureWithDapperController : Controller
    {
        IRepositoryManager<DatabaseTableModel> _databaseTableModel;
        public AspNetLayeredArchitectureWithDapperController(IRepositoryManager<DatabaseTableModel> databaseTableModel)
        {
            _databaseTableModel = databaseTableModel;
        }
        public IActionResult Index()
        {
            var data = _databaseTableModel.Get(1);
            return View();
        }
    }
}