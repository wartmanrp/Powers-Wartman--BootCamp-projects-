using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Service
{
   /// <summary>
   /// The <c>Cts.Venture.Service</c> is responsible for fulfilling system use cases. Thus, services follow the façade design pattern without
   /// having to contain the business logic unless in an exceptional cases. The layer is responsible for interacting with the data layer and
   /// orchestrating data management using LINQ queries. The layer wraps all changes to the domain layer in a unit of work; therefore, 
   /// services always initiate a transaction wherever necessary for data integrity.
   /// </summary>
   internal class NamespaceDoc { }
}

namespace Cts.Venture.Service.DTOs
{
   /// <summary>
   /// <para>
   /// The <c>Cts.Venture.Service.DTOs</c> contains POCO objects used as Data Transfer objects. The DTO supports complex data visualization required by  
   /// the view component. When complex data visualization is required, the services layer aggregates all of the data into a DTO instead of an 
   /// entity and returns it to the presentation layer for display.
   /// </para>
   /// <para>
   /// When entities are inadequate for the data presentation, the application should utilize DTOs as necessary. The design intent is to allow a greater 
   /// separation of concern as well as a physical boundary between the presentation and service layer. The developer should define service contracts if 
   /// a physical boundary is necessary. 
   /// </para>
   /// </summary>
   internal class NamespaceDoc { }
}

namespace Cts.Venture.Service.Exceptions
{
   /// <summary>
   /// The <c>Cts.Venture.Service.Exceptions</c> is responsible for handling exceptions in the service layer dealing with business rules and logics.
   /// </summary>
   internal class NamespaceDoc { }
}
