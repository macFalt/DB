using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouseMVC.Application.Interfaces;

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


        public IActionResult AddCustomer()
        {


            return View();
        }

        //[HttpPost]
        //public IActionResult AddCustomer(CustomerModel model)
        //{
        //    var id = customerService.AddCustomer(model);


        //    return View();
        //}
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

