using System;
using AutoMapper;
using FluentValidation;
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
	public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
	{
		public NewCustomerValidation()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.NIP).Length(10);
			RuleFor(x => x.Regon).Length(9,14);
			RuleFor(x => x.Name).MaximumLength(255);
        }

	}
}

