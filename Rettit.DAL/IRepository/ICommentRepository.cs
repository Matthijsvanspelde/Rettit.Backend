using Rettit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rettit.DAL.IRepository
{
    public interface ICommentRepository
    {
        bool AddComment(Comment comment);
    }
}
