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
            try
            {
                
                var value1 = _customerService.TGetByID(model.SenderID);
                var value2 = _customerService.TGetByID(model.ReceiverID);

                if (value1 == null || value2 == null)
                {
                    ViewBag.Message = "Gönderen veya Alıcı bulunamadı.";
                    return View();
                }

                value1.CustomerBalance -= model.Amount;
                value2.CustomerBalance += model.Amount;

          
                List<Customer> modifiedCustomers = new List<Customer> { value1, value2 };
                _customerService.TMultiUpdate(modifiedCustomers);

              
                ViewBag.Message = "İşlem başarılı bir şekilde gerçekleştirildi!";
            }
            catch (Exception ex)
            {
                
                ViewBag.Message = "Bir hata oluştu: " + ex.Message;
            }

            return View();
        }

    }
}
