using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDesignPattern.BusinessLayer.Abstract;
using UnitOfWorkDesignPattern.EntityLayer.Concrete;
using UnitOfWorkDesignPattern.PresentationLayer.Models;

namespace UnitOfWorkDesignPattern.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
    
            var value1 = _customerService.TGetByID(model.SenderID);
            var value2 = _customerService.TGetByID(model.ReceiverID);

            value1.CustomerBalance-=model.Amount;
            value2.CustomerBalance+=model.Amount;
            List<Customer>modifiledCustomer = new List<Customer> { value1, value2 };


            _customerService.TMultiUpdate(modifiledCustomer);
            return View();
        }
    }
}
