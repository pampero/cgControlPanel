using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAL
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public void GetByExecutedJob()
        {
            throw new NotImplementedException();
        }
    }

}
