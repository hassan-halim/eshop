using AutoMapper;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Vendor, VendorResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(c => new ContactResource { Phone = c.Phone, Address = c.Address, Email = c.ContactEmail }));

            //API Resources to domain
            CreateMap<VendorResource, Vendor>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Address, opt => opt.MapFrom(vr => vr.Contact.Address))
                .ForMember(v => v.Phone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail, opt=> opt.MapFrom(vr=>vr.Contact.Email));

            CreateMap<Product, ProductResource>()
                //.ForMember(pr => pr.Features, opt => opt.MapFrom(p => p.Features.Select(fr => new FeatureResource { Id = fr.Feature.Id, Name = fr.Feature.Name })));
                .ForMember(pr => pr.Features, opt => opt.MapFrom(p => p.Features.Select(i => i.FeatureID)));
            //.ForMember(pr => pr.Vendor, opt => opt.Ignore());

            CreateMap<ProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Features, opt => opt.MapFrom(pf => pf.Features.Select(f => new ProductFeature { FeatureID = f })));
            CreateMap<Cart, CartResource>();
            //CreateMap<InputProductResource, Product>()
            //    .ForMember(p => p.Id, opt => opt.Ignore())
            //    .ForMember(p => p.Features, opt => opt.Ignore())
            //    .AfterMap((pr, p) =>
            //    {
            //        //Remove deleted features
            //        var removedFeatures = new List<ProductFeature>();
            //        foreach (var f in p.Features)
            //            if (!pr.Features.Contains(f.FeatureID))
            //                //p.Features.Remove(f);
            //                removedFeatures.Add(f);
            //        foreach (var f in removedFeatures)
            //            p.Features.Remove(f);
            //        //Add new features
            //        foreach (var id in pr.Features)
            //            if (!p.Features.Any(f => f.FeatureID == id))
            //                p.Features.Add(new ProductFeature { FeatureID = id, ProductId = pr.Id });
            //    });



            CreateMap<InputProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Features, opt => opt.Ignore())
                .AfterMap((pr, p) =>
                {
                    
                    var removedFeatures = p.Features.Where(f => !pr.Features.Contains(f.FeatureID));
                    //we used where instead of select because select performs projection to the lamda expresion which is bollean here, where is used to use the condition as a filter condition
                    foreach (var f in removedFeatures.ToList())
                        p.Features.Remove(f);

                    //even better approach
                    var addedFeatures = pr.Features.Where
                        (id => ! p.Features.Any(f => f.FeatureID == id))
                        .Select(id=> new ProductFeature { FeatureID = id});
                    foreach (var f in addedFeatures)
                        p.Features.Add(f);

                });

        }
    }
}
