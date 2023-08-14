using System;
using Aien_Test.Common.DTOs.Contract;

namespace Aien_Test.Application.Services.Interfaces
{
	public interface IContractService
	{
		#region queries
		Task<List<ContractList>> GetContractList(CancellationToken cancellationToken);
		#endregion
	}
}

