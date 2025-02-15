﻿using Microsoft.EntityFrameworkCore;
using Reddit.Logic.ILogic;
using Rettit.DAL;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reddit.Logic.Logic
{
    public class FollowLogic : IFollowLogic
    {
        private readonly Context _context;

        public FollowLogic(Context context)
        {
            _context = context;
        }

        public bool AddFollow(Follow follow)
        {
            try
            {
                _context.Follow.Add(follow);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool RemoveFollow(Follow follow)
        {
            try
            {
                var itemToRemove = _context.Follow.FirstOrDefault(e => e.UserId == follow.UserId && e.SubForumId == follow.SubForumId);
                if (itemToRemove == null)
                {
                    return false;
                }
                else
                {
                    _context.Follow.Remove(itemToRemove);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool FollowExists(Follow follow)
        {
            return _context.Follow.Any(e => e.UserId == follow.UserId && e.SubForumId == follow.SubForumId);
        }

        public IEnumerable<Follow> GetSubscribedPosts(long UserId)
        {
            var posts = _context.Follow
                .Where(c => c.UserId == UserId)
                .Include(c => c.SubForum)
                .ThenInclude(c => c.Posts)
                .ThenInclude(c => c.Comments)
                .ToList();
            return posts;
        }
    }
}

