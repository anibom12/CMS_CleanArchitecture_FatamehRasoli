using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presistence.EF.Hilo;

public interface IHiloIdGenerator
{
    long GetNextId<T>();
}
