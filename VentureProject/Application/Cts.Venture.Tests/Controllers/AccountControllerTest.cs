using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cts.Venture.Web.Controllers;
using System.Web.Mvc;
using System.Web;
using System.IO;
using Cts.Venture.Domain;

namespace Cts.Venture.Tests.Controllers
{
   [TestClass]
   public class AccountControllerTest
   {
      [TestMethod]
      public void Login()
      {
         AccountController controller = new AccountController();
         ViewResult view = controller.Login() as ViewResult;

         Assert.AreEqual("Index", view.ViewName);

      }
   }
}
