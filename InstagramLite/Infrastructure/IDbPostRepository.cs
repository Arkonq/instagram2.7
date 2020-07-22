using System.Collections;
using System.Collections.Generic;
using InstagramLite.Models;

namespace InstagramLite.Infrastructure
{
    public interface IDbPostRepository
    {
        DbPost Create(DbPost post);

        IList<DbPost> GetAll();

        DbPost Get(int id);
    }
}