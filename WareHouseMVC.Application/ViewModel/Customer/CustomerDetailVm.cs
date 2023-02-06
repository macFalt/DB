using System;
using AutoMapper;
using WareHouseMVC.Application.Mapping;

namespace WareHouseMVC.Application.ViewModel.Customer
{
	public class CustomerDetailVm : IMapFrom<WareHouseMVC.Domain.Model.Customer>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string NIP { get; set; }

		public string Regon { get; set; }

		public string CEOFullName { get; set; }

		public string FirstLineOfContactInformation { get; set; }

		public List<AddressForListVm> Addresses { get; set; }

		public List<ContactDetailListVm> Emails { get; set; }

		public List<ContactDetailListVm> PhoneNumbers { get; set; }

        public void Mapping(Profile profile)
        {
			profile.CreateMap<WareHouseMVC.Domain.Model.Customer, CustomerDetailVm>()
			.ForMember(s => s.CEOFullName, opt => opt.MapFrom(d => d.CEOName + " " + d.CEOLastName))
			.ForMember(s => s.FirstLineOfContactInformation, opt => opt.MapFrom(d => d.CustomerContactInformation.FirstName + " " +
			d.CustomerContactInformation.LastName))
			.ForMember(s => s.Addresses, opt => opt.Ignore())
			.ForMember(s => s.Emails, opt => opt.Ignore())
			.ForMember(s => s.PhoneNumbers, opt => opt.Ignore());

            //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            //.ForMember(d => d.NIP, opt => opt.MapFrom(s => s.NIP));
        }



    }
}

