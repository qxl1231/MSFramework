using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using Client.Domain.AggregateRoot;

namespace Client.Infrastructure.EntityConfigurations
{
	public class ClientAccountEntityTypeConfiguration : EntityTypeConfigurationBase<ClientAccount>
	{
		public override Type DbContextType => typeof(ClientContext);

		public override void Configure(EntityTypeBuilder<ClientAccount> clientAccountConfiguration)
		{
			clientAccountConfiguration.HasKey(o => o.Id);

			clientAccountConfiguration.Property<DateTime>("CreationTime").IsRequired();

			clientAccountConfiguration.Property<Guid>("ClientId").IsRequired();

			clientAccountConfiguration.Property<string>("Name").IsRequired();

			clientAccountConfiguration.Property<string>("Type").IsRequired();

			clientAccountConfiguration.Property<string>("State").IsRequired();

			clientAccountConfiguration.Property<DateTime>("Start").IsRequired();
			
			clientAccountConfiguration.Property<DateTime>("End").IsRequired();
		}
	}
}