using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cts.Venture.Web.Controllers;
using System.Web;
using System.IO;

namespace Cts.Venture.Tests.Controllers
{
   [TestClass]
   public class DemoControllerTest
   {
      [TestMethod]
      public void Index()
      {
         // Arrange
         HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
         Demo1Controller controller = new Demo1Controller();

         // Act
         ViewResult result = null; // controller.Index("", "", "", null) as ViewResult;

         // Assert
         Assert.AreEqual("This page is for demo purpose.", result.ViewBag.Message);
      }

      [TestMethod]
      public void About()
      {
         Demo1Controller controller = new Demo1Controller();
         ViewResult result = controller.SignalrSender() as ViewResult;
         Assert.IsNotNull(result);
      }

      [TestMethod]
      public void Contact()
      {
         Demo1Controller controller = new Demo1Controller();
         ViewResult result = controller.Responsive() as ViewResult;
         Assert.IsNotNull(result);
      }
   }
}
