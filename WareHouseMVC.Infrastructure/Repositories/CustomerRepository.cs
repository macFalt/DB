using System;
using WareHouseMVC.Domain.Interface;
using WareHouseMVC.Domain.Model;

namespace WareHouseMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;

        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers.Where(p => p.IsActive);
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == customerId);
        }
    }
}

