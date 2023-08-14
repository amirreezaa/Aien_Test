using System;
using System.Threading;
using Aien_Test.DataAccess.DbContexts;
using Aien_Test.DataAccess.Repositories.Interfaces;
using Aien_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aien_Test.DataAccess.Repositories
{
    public class ContractRepository : IContractRepository
    {
        /// <summary>
        /// It would be better to have IRepository and Repository class that have these codes!
        /// </summary>
		protected readonly Test_DbContext _dbContext;
        public DbSet<Contract> Entities { get; }
        public virtual IQueryable<Contract> Table => Entities;
        public virtual IQueryable<Contract> TableNoTracking => Entities.AsNoTracking();

        public ContractRepository(Test_DbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<Contract>();
        }

        public async Task ContractInsertRangeAsync(List<Contract> contracts, CancellationToken cancellationToken)
        {
            await Entities.AddRangeAsync(contracts, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Contract>> ContractList(CancellationToken cancellationToken)
        {
            List<Contract> contracts =
                Entities.AsNoTracking()
                .ToList();

            return contracts;
        }

        public void ContractInsertRange(List<Contract> contracts)
        {
            Entities.AddRange(contracts);
            _dbContext.SaveChanges();
        }
    }
}

