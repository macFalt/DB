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

            _custService = _custService;




        }


        //GET: /<controller>/
        public IActionResult Index()
        {
            //utowrzyc widok dla akcji
            //tabela z klientami
            //filtorwanie klientow
            //przygotowac dane
            //przekazac filtry do serwisu
            //serwis musi przygotowac dane
            //serwis musi zwrocic dane do controlera w odpowiednim formacie
            var model = _custService.GetAllCustomerForList();
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

