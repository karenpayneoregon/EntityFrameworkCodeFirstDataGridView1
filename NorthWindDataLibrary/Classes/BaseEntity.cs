using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDataLibrary.Classes
{
    public class BaseEntity
    {
        [NotMapped]
        public DateTime? DateCreated { get; set; }
        [NotMapped]
        public string UserCreated { get; set; }
        [NotMapped]
        public DateTime? DateModified { get; set; }
        [NotMapped]
        public string UserModified { get; set; }
    }
}
