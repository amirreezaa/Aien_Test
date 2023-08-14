using System;
using Aien_Test.Application.Services.Interfaces;
using Aien_Test.DataAccess.Repositories.Interfaces;
using Aien_Test.Domain.Entities;

namespace Aien_Test.Application.Services
{
	public class DataInitializer : IDataInitializer
	{
        private readonly IContractRepository _contractRepos;
        public DataInitializer(IContractRepository contractRepos)
        {
            _contractRepos = contractRepos;
        }

        public void InitializeContractData()
        {
            if (!_contractRepos.TableNoTracking.Any())
            {
                List<Contract> contractList = new();
                Contract contract1 = new()
                {
                    Code = "123124",
                    Name = "contract1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                };

                Contract contract2 = new()
                {
                    Code = "123124",
                    Name = "contract2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                };

                Contract contract3 = new()
                {
                    Code = "123124",
                    Name = "contract3",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                };

                _contractRepos.ContractInsertRange(new List<Contract> { contract1, contract2, contract3 });
            }
        }
    }
}

