using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;

namespace Sample
{
    public class Member : BaseAggregateRoot
    {
        private ICollection<Activity> _activities = new Collection<Activity>();

        public virtual ICollection<Activity> Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }
    }
}
