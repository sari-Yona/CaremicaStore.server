using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace IDal_Repository
{
    public interface IDalRepository<T>
    {
        public Task<List<T>> SelectAll();

        public Task<int> Add(T c);

        public Task<int> Delete(int id);

        public Task<int> Update(int id, T newC);

        public Task<T> SelectById(int id);

    }
}
