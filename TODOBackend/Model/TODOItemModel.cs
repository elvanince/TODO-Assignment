using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class TODOItemModel
    {
        public Guid Id { get; set; }
        public String  name { get; set; }
        public Boolean status { get; set; }
        public DateTime creationDate { get; set; }
    }
}
