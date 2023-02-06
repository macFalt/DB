using System;
using WareHouseMVC.Application.ViewModel;
using WareHouseMVC.Application.ViewModel.Customer;

namespace WareHouseMVC.Application.Interfaces
{
	public interface ICustomerService
	{
        ListCustomerForListVm GetAllCustomerForList();

        int AddCustomer(NewCustomerVm customer);

        CustomerDetailVm GetCustomerDetail(int customerId);





    }
}

