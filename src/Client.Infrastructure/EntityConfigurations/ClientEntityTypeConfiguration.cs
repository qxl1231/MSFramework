using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ClientEntity = Client.Domain.AggregateRoot.Client;

namespace Client.Infrastructure.EntityConfigurations
{
	public class ClientEntityTypeConfiguration : EntityTypeConfigurationBase<ClientEntity>
	{
		public override Type DbContextType => typeof(ClientContext);


		public override void Configure(EntityTypeBuilder<ClientEntity> clientConfiguration)
		{
			clientConfiguration.HasKey(o => o.Id);

			//Address value object persisted as owned entity type supported since EF Core 2.0
//			clientConfiguration.OwnsOne(o => o.Address);

			clientConfiguration.Property<string>("Name").IsRequired();

			clientConfiguration.Property<string>("ShortName").IsRequired();

			clientConfiguration.Property<string>("Type").IsRequired();

			clientConfiguration.Property<string>("City").IsRequired();

			clientConfiguration.Property<string>("Province").IsRequired();

			clientConfiguration.Property<string>("Country").IsRequired();

			clientConfiguration.Property<string>("Level").IsRequired();

			clientConfiguration.Property<string>("PaymentType").IsRequired();

			clientConfiguration.Property<string>("ScoringCycle").IsRequired(false);

			clientConfiguration.Property<string>("State").IsRequired();

			clientConfiguration.Property<bool>("Active").IsRequired();

			clientConfiguration.Property<DateTime>("CreationTime").IsRequired();

			var navigationClientUsers = clientConfiguration.Metadata.FindNavigation(nameof(ClientEntity.ClientUsers));
			var navigationClientSales = clientConfiguration.Metadata.FindNavigation(nameof(ClientEntity.ClientSales));
			var navigationClientAccounts =
				clientConfiguration.Metadata.FindNavigation(nameof(ClientEntity.ClientAccounts));

			// DDD Patterns comment:
			//Set as field (New since EF 1.1) to access the ClientItem collection property through its field
			navigationClientUsers.SetPropertyAccessMode(PropertyAccessMode.Field);
			navigationClientSales.SetPropertyAccessMode(PropertyAccessMode.Field);
			navigationClientAccounts.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}