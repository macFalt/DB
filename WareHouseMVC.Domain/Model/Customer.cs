﻿using System;
namespace WareHouseMVC.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NIP { get; set; }

        public string Regon { get; set; }

        public string CEOName { get; set; }

        public string CEOLastName { get; set; }

        public bool IsActive { get; set; }

        public byte[] LogoPic { get; set; }






        public CustomerContactInformation CustomerContactInformation { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }



    }
}
