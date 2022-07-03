using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTCData;

namespace PTC.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      TrainingProductViewModel vm = new TrainingProductViewModel();

      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Index(TrainingProductViewModel vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }

  }
}