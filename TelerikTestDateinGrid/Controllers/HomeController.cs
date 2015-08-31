using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikTestDateinGrid.Helpers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace TelerikTestDateinGrid.Controllers
{

    public class DateDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

    }


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";


            return View();
        }

        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                TimeZone serverZone = TimeZone.CurrentTimeZone;

                IList<DateDTO> dateDTOList = new List<DateDTO>();

                DateDTO dateDTO1 = new DateDTO
                {
                    Id = 1,
                    Name = "Date Local",
                    StartDate = DateTime.Now,
                };
                dateDTOList.Add(dateDTO1);

                DateDTO dateDTO2 = new DateDTO
                {
                    Id = 2,
                    Name = "Date UTC",
                    StartDate = DateTime.UtcNow,
                };
                dateDTOList.Add(dateDTO2);

                DateDTO dateDTO3 = new DateDTO
                {
                    Id = 3,
                    Name = "Date Converted to Local Time",
                    StartDate = ClientTimeZoneHelper.ConvertToLocalTime(dateDTO1.StartDate),
                };
                dateDTOList.Add(dateDTO3);



                DateDTO dateDTO4 = new DateDTO
                {
                    Id = 4,
                    Name = "Date UTC Converted to Local Time",
                    StartDate = ClientTimeZoneHelper.ConvertToLocalTime(dateDTO2.StartDate),
                };
                dateDTOList.Add(dateDTO4);

                DateDTO dateDTO5 = new DateDTO
                {
                    Id = 5,
                    Name = "Set Date 8/31/15 10:00 AM",
                    StartDate = DateTime.Parse("8/31/15 10:00 AM")
                };
                dateDTOList.Add(dateDTO5);



                return this.Json(dateDTOList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(ModelState.ToDataSourceResult());
            }

        }//public JsonResult Get([DataSourceRequest]DataSourceRequest request)



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
