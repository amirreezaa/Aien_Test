using System;
using Aien_Test.Common.DTOs.Contract;
using Aien_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aien_Test.DataAccess.Repositories.Interfaces
{
	public interface IContractRepository
	{
        DbSet<Contract> Entities { get; }
        IQueryable<Contract> Table { get; }
        IQueryable<Contract> TableNoTracking { get; }

        #region commands
        Task ContractInsertRangeAsync(List<Contract> contracts , CancellationToken cancellationToken);
        void ContractInsertRange(List<Contract> contracts);
        #endregion

        #region queries
        Task<List<Contract>> ContractList(CancellationToken cancellationToken);
		#endregion
	}
}

