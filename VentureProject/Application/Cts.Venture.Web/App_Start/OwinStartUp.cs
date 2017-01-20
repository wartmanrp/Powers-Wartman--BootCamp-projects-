using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cts.Venture.Web.App_Start.OwinStartUp))]

namespace Cts.Venture.Web.App_Start
{
   /// <summary>
   /// 
   /// </summary>
   public class OwinStartUp
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="app"></param>
      public void Configuration(IAppBuilder app)
      {
         // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
      }
   }
}
