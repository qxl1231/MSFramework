using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ClientEntity=Client.Domain.AggregateRoot.Client;

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

			clientConfiguration.Property<DateTime>("CreationTime").IsRequired();
			clientConfiguration.Property<bool>("IsDeleted").IsRequired();
			clientConfiguration.Property<string>("UserId").IsRequired();
			clientConfiguration.Property<int>("ClientStatusId").IsRequired();
			clientConfiguration.Property<string>("Description").IsRequired(false);

			var navigation = clientConfiguration.Metadata.FindNavigation(nameof(ClientEntity.ClientUsers));
            
			// DDD Patterns comment:
			//Set as field (New since EF 1.1) to access the ClientItem collection property through its field
			navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}