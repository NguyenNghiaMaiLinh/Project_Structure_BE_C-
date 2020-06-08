using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Repository
{
  public  class FollowerRepository : RepositoryBase<Follower>, IFollowerRepository
    {
        private DataContext _dataContext;
        public FollowerRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

        public Follower checkExsist(string author, string follower)
        {
            var result = _dataContext.Follower.Where(f => f.AuthorId == author && f.FollowerId == follower && f.IsDelete == false).FirstOrDefault();
            return result;
        }

        public IEnumerable<Follower> getALlFollowerByAuthor(string author)
        {
            var result = _dataContext.Follower.Where(f => f.AuthorId == author && f.IsDelete == false);
            return result;
        }
    }
}
