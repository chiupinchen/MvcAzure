using AutoMapper;
using MvcAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcAzure
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.CreateMap<Person, PersonListViewModel>()
                .ForMember(vm=>vm.PersonName, opt=>opt.MapFrom(src=>src.Name))
                .ForMember(vm=>vm.PersonAge,opt=>opt.MapFrom(src=>src.Age))
                .ForMember(vm=>vm.TopDegreeName,opt=>opt.MapFrom(src=> (src.Degrees.Count==0)?null:src.Degrees.First().Name))
                .ForMember(vm =>vm.TopDegreeGPA, opt => opt.MapFrom(src => (src.Degrees.Count == 0) ? 0 : src.Degrees.First().GPA));


            Mapper.CreateMap<PersonListViewModel, Person>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dto => dto.Age, opt => opt.MapFrom(src => src.PersonAge))
                
                .ForMember("Degrees", opt => opt.MapFrom(src => new List<Degree>() {
                        new Degree { GPA = src.TopDegreeGPA , Name = src.TopDegreeName}
                    }));

                


        }
    }
}