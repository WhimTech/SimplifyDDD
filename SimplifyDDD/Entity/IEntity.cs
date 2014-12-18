using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.Entity
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreateTime { get; set; }
    }
}
