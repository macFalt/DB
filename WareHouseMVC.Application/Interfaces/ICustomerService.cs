using System;
using WareHouseMVC.Application.ViewModel;
using WareHouseMVC.Application.ViewModel.Customer;

namespace WareHouseMVC.Application.Interfaces
{
	public interface ICustomerService
	{
        ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString);

        int AddCustomer(NewCustomerVm customer);

        CustomerDetailVm GetCustomerDetail(int customerId);

        void DeleteCustomer(int id);

        NewCustomerVm GetCustomerForEdit(int id);

        void UpdateCustomer(NewCustomerVm model);





    }
}

