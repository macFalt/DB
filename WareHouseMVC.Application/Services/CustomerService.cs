using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using WareHouseMVC.Application.Interfaces;
using WareHouseMVC.Application.ViewModel;
using WareHouseMVC.Application.ViewModel.Customer;
using WareHouseMVC.Domain.Interface;
using WareHouseMVC.Domain.Model;

namespace WareHouseMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }



        public int AddCustomer(NewCustomerVm customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;

        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString)
        {

            var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();//zostanie automatycznie zmapowana do VM

            //var customers = _customerRepo.GetAllActiveCustomers()
            //    .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();//zostanie automatycznie zmapowana do VM

            var customersToShow = customers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var customerList = new ListCustomerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customersToShow,
                Count = customers.Count

            };
            return customerList;


            //Opcja 1
            //var customers = _customerRepo.GetAllActiveCustomers();
            //ListCustomerForListVm result = new ListCustomerForListVm();
            //result.Customers = new List<CustomerForListVm>();
            //foreach(var customer in customers)
            //{
            //    var custVm = new CustomerForListVm()
            //    {
            //            Id=customer.Id,
            //            Name=customer.Name,
            //            NIP=customer.NIP,
            //   };
            //   result.Customers.Add(custVm);
            //}
            //result.Count = result.Customers.Count();
            //return result;


        }

        public CustomerDetailVm GetCustomerDetail(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var customerVm = _mapper.Map<CustomerDetailVm>(customer);



            //var customerVm = new CustomerDetailVm();
            //customerVm.Id = customer.Id;
            //customerVm.Name = customer.Name;
            //customerVm.NIP = customer.NIP;
            //customerVm.Regon = customer.Regon;
            //customerVm.CEOFullName = customer.CEOName + " " + customer.CEOLastName;
            //var custConInfo = customer.CustomerContactInformation;
            //customerVm.FirstLineOfContactInformation = custConInfo.FirstName + " " + custConInfo.LastName;

            customerVm.Addresses = new List<AddressForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailListVm>();
            customerVm.Emails = new List<ContactDetailListVm>();


            foreach (var address in customer.Addresses)
            {
                var add = new AddressForListVm()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City,
                };
                customerVm.Addresses.Add(add);

            }
            return customerVm;
        }

        public NewCustomerVm GetCustomerForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(NewCustomerVm model)
        {
            throw new NotImplementedException();
        }
    }
}

