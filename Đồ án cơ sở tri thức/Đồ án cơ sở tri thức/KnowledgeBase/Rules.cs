using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Đồ_án_cơ_sở_tri_thức.KnowledgeBase
{
    class Rules
    {
        [JsonProperty("GT")]
        public string[] GiaThiet { get; set; }

        [JsonProperty("KL")]
        public string[] KetLuan { get; set; }

    }
}
