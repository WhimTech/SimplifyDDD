using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;

namespace Sample
{
    public class Activity : BaseAggregateRoot
    {
        private ICollection<Member> _members = new Collection<Member>();

        public virtual ICollection<Member> Members
        {
            get { return _members; }
            set { _members = value; }
        }
    }
}
