using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class AzureOpenAIOptions
    {
        public string ResourceName { get; set; }
        public string Key { get; set; }
        public string DeploymentId { get; set; }
        public string ApiVersion { get; set; }
    }
}
