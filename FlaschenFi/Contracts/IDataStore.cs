using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlaschenFi.Contracts
{
    public interface IDataStore<T, TID>
    {
        Task<T> GetById(TID id);
        Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false);
    }
}
