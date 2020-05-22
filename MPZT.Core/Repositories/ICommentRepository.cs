﻿using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface ICommentRepository: IDataRepository<Comment>
    {
        IList<Comment> GetComments(int projectId);
    }
}
