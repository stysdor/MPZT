using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface IProjectRepository : IDataRepository<Project>
    {
        Project GetByArea(int areaId);
    }
}
