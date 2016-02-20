using System;
using System.Linq;
using Giftomatic.App_Start;
using Giftomatic.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Giftomatic.Tests.Fakes;
using System.Web.Mvc;
using System.Collections.Generic;
using Giftomatic.Data;
using Giftomatic.Services;

namespace Giftomatic.Tests.Controllers
{
  [TestClass]
  public class HomeControllerTests
  {
    private FakePredictionDataRepository _repo;
    private HomeController _ctrl;

    [TestInitialize]
    public void Init()
    {
      _repo = new FakePredictionDataRepository();
            //_ctrl = new HomeController(new MockMailService(), _repo);
      _ctrl = new HomeController(_repo);

        }

    [TestMethod]
    public void IndexCanRender()
    {
      var result = _ctrl.Index();
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void IndexHasData()
    {
      var result = _ctrl.Index() as ViewResult;
      var topics = result.Model as IEnumerable<Topic>;

      Assert.IsNotNull(result.Model);
      Assert.IsNotNull(topics);
      Assert.IsTrue(topics.Count() > 0);

    }
  }
}
