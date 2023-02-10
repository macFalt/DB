using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouseMVC.Application.Interfaces;
using WareHouseMVC.Application.ViewModel;
using WareHouseMVC.Application.ViewModel.Customer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouseMVC.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _custService;


        public CustomerController(ICustomerService customerService )
        {

            _custService = customerService;
        }


        [HttpGet]
        public IActionResult Index()

        { 
            var model = _custService.GetAllCustomerForList(2,1,"");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _custService.GetAllCustomerForList(pageSize,pageNo.Value,searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()

        {


            return View(new NewCustomerVm());
        }

        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _custService.AddCustomer(model);


            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddNewAddressForClient(int customerId)
        {

            return View();
        }

        //[HttpPost]
        //public IActionResult AddNewAddressForClient(AddressModel model)
        //{
        //    return View();
        //}

        //public IActionResult ViewCustomer(int customerId)
        //{
        //    var customerModel = customerService.GetCustomerDetails(customerId);
        //    return View(customerModel);


        //}
    }
}

