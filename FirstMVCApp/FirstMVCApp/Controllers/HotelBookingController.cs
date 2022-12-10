using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HotelBookingController : Controller
    {
        public IActionResult Index()
        {
            var old = DateTime.Now.AddYears(-12);
            var hb = new HotelBooking()
            { Id= 1, GuestName= "David", DateStart= old, DateEnd= DateTime.Now};
            return View(hb);
        }
    }
}
