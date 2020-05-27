﻿using Rettit.Models;

namespace Rettit.DAL.IRepository
{
    public interface IFollowRepository
    {
        bool AddFollow(Follow follow);
        bool FollowExists(Follow follow);
        bool RemoveFollow(Follow follow);
    }
}
