using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.ViewModels;

namespace Web.ViewComponents
{
    public class MainPageSlider : ViewComponent
    {
        public List<SliderModel> SliderList;
        private readonly IWebHostEnvironment _env;
        public MainPageSlider(IWebHostEnvironment env)
        {
            SliderList = new List<SliderModel>();
            _env = env;
        }
        public IViewComponentResult Invoke()
        {
            SliderList.Add(new SliderModel()
            {
                Index = 1,
                Active = true,
                Path = "images/slider/greenworld.jpg",
                SubTitle = "Green",
                Title = "World",
                CssClass = "rgba-black-slight"
            }
            );
            SliderList.Add(new SliderModel()
            {
                Index = 2,
                Path = "images/slider/mountain.jpg",
                SubTitle = "Mountain",
                Title = "Snow",
                CssClass = "rgba-black-light"
            }
            );
            SliderList.Add(new SliderModel()
            {
                Index = 3,
                Path = "images/slider/sunshine_evening.jpg",
                SubTitle = "Sun Shine",
                Title = "Evening",
                CssClass = "rgba-black-strong"
            }
            );

            SliderViewModel SliderView = new SliderViewModel()
            {
                SliderList = SliderList
            };


            return View(SliderView);
        }
    }
}
