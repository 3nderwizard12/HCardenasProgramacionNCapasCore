using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Role
    {
        public byte IdRole { get; set; }
        public string Name { get; set; }

        public List<object> Roles { get; set; }
    }
}
