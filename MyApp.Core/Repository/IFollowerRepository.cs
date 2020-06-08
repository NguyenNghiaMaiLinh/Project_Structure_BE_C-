using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using System.Collections.Generic;

namespace MyApp.Core.Repository
{
    public  interface IFollowerRepository :IRepository<Follower>
    {
        IEnumerable<Follower> getALlFollowerByAuthor(string author);
        Follower checkExsist(string author, string follower);
    }
}
