using System;
using Aien_Test.Application.Services.Interfaces;
using Aien_Test.Common.DTOs.Contract;
using Aien_Test.Common.Utilities;
using Aien_Test.DataAccess.Repositories.Interfaces;

namespace Aien_Test.Application.Services
{
	public class ContractService : IContractService
	{
        private readonly IContractRepository _contractRepos;
        public ContractService(IContractRepository contractRepos)
        {
            _contractRepos = contractRepos;
        }

        public async Task<List<ContractList>> GetContractList(CancellationToken cancellationToken)
        {
            var contracts = _contractRepos
                .TableNoTracking
                .Select(x => new ContractList(
                    x.Name,
                    x.Code ,
                    x.StartDate.ConvertToPersianDate() ,
                    x.EndDate.ConvertToPersianDate())
                { })
                .ToList();

            return contracts;
        }
    }
}

