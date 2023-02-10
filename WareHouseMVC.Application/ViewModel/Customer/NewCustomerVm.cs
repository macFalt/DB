using System;
using AutoMapper;
using WareHouseMVC.Application.Mapping;

namespace WareHouseMVC.Application.ViewModel.Customer
{
	public class NewCustomerVm : IMapFrom<WareHouseMVC.Domain.Model.Customer>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string NIP { get; set; }

		public string Regon { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, WareHouseMVC.Domain.Model.Customer>();

        }




    }
}

