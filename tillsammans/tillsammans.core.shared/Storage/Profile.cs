using System.Collections.Generic;
using System.Linq;

namespace tillsammans.Storage
{
    public class Profile
    {

        public string id { get; set; }
        public string name { get; set; }
        public string passwordToken { get; set; }
        public string salt { get; set; }

    }

}
