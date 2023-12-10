using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct
{
    public interface IServiceModel<T>
    {
        IEnumerable<T> get();
        T Upd<C>(C Id,T Enty);
        T Add(T Enty);
        T get<C>(C Id);
    }
}
