using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   public class ProjectTeamDto
   {
      public IEnumerable<ResourceDto> TeamMembers { get; set; }
   }
}
