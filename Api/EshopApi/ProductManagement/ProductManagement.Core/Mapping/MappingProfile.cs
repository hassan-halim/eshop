using AutoMapper;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        { 
            //CreateMap<Vendor, VendorResource>()
            //    .ForMember(vr => vr.Contact, opt => opt.MapFrom(c => new ContactResource { Phone = c.Phone, Address = c.Address, Email = c.ContactEmail }));
        }
    }
}
