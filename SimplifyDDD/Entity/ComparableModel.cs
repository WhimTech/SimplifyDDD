using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.Entity
{
    public class ComparableModel : BaseModel, IEquatable<ComparableModel>
    {
        public override int GetHashCode()
        {
            return (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + this.Id).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public bool Equals(ComparableModel obj)
        {
            return Id == obj.Id;
        }
    }
}
