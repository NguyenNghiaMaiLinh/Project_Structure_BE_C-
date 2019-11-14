using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Repository
{
    public class ProjectMembersRepository : RepositoryBase<ProjectMembers>, IProjectMembersRepository
    {
        private DataContext _dataContext;
        public ProjectMembersRepository(IDbFactory dbFactory, IServiceProvider serviceProvider, DataContext dataContext) : base(dbFactory, serviceProvider)
        {
            _dataContext = dataContext;
        }

    }
}
