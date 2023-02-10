using System;
using WareHouseMVC.Domain.Model;

namespace WareHouseMVC.Domain.Interface
{
	public interface ICustomerRepository
	{
		IQueryable<Customer> GetAllActiveCustomers();

		Customer GetCustomer(int customerId);

		int AddCustomer(Customer customer);








	}
}

