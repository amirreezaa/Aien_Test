using Aien_Test.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aien_Test.Domain.Entities
{
    public class Contract : BaseEntity
	{		
		public string Name { get; set; } = string.Empty;
		public string Code { get; set; } = string.Empty;	
	}

    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);

        }
    }
}

