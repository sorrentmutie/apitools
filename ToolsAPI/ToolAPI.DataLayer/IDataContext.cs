using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolAPI.DataLayer
{
    public  interface IDataContext
    {
        IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class;
        void Insert<T>(T item) where T : class;
        Task SaveAsync();
    }
}
