using AutoMapper;
using MvcAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAzure.Controllers
{
    public class AutoMapperTestController : Controller
    {
        //
        // GET: /AutoMapperTest/

        public ActionResult Index()
        {
            //see global.asa

            TestDBEntities oDB = new TestDBEntities();
            Person person = oDB.People.First();

            //Domain object to ViewModel
            PersonListViewModel plvm = Mapper.Map<PersonListViewModel>(person);

            //ViewModel to Domain object
            Person personFromVM = Mapper.Map<Person>(plvm);
            

            return View();
        }

       

    }
}
