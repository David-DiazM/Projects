using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HelloWorldController : Controller
    {

        private static List<DogViewModel> dogs = new List<DogViewModel>();

        public IActionResult Index()
        {
            
            return View(dogs);
        }

        public IActionResult Create()
        {
            var dogvm = new DogViewModel();
            return View(dogvm);
        }

        public IActionResult CreateDog(DogViewModel dog)
        {
            dogs.Add(dog);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Hello()
        {
            DogViewModel dog = new DogViewModel()
            { Name="Apollo", Age= 3};

            return View(dog);
        }
    }
}
