using System;
namespace Aien_Test.Common.DTOs.Contract
{
	public record InsertContractCommand(
		string Name,
		string Code,
		DateTime StartDate,
		DateTime EndDate
		){}
}

