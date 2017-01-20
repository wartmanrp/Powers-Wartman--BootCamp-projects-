using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.MakeReady
{
    class ReplaceCriteria
    {
        public string ClientKey { get { return "-c"; } }
        public string Client { get; set; }
        public string ProjectNameKey { get { return "-n"; } }
        public string ProjectName { get; set; }
        public bool IsProjectNameValid()
        {
            return (!string.IsNullOrEmpty(ProjectName) && ProjectName.Length > 0);
        }

        public bool IsClientNameValid()
        {
            return (!string.IsNullOrEmpty(Client) && Client.Length > 0);
        }
    }
}
