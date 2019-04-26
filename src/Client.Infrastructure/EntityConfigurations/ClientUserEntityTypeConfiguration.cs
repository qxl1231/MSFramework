using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using Client.Domain.AggregateRoot;

namespace Client.Infrastructure.EntityConfigurations
{
	public class OrderItemEntityTypeConfiguration : EntityTypeConfigurationBase<ClientUser>
	{
		public override Type DbContextType => typeof(ClientContext);
		
		public override void Configure(EntityTypeBuilder<ClientUser> orderItemConfiguration)
		{
			orderItemConfiguration.HasKey(o => o.Id);

			orderItemConfiguration.Property<decimal>("Discount")
				.IsRequired();

			orderItemConfiguration.Property<int>("ProductId")
				.IsRequired();

			orderItemConfiguration.Property<string>("ProductName")
				.IsRequired();

			orderItemConfiguration.Property<decimal>("UnitPrice")
				.IsRequired();

			orderItemConfiguration.Property<int>("Units")
				.IsRequired();

			orderItemConfiguration.Property<string>("PictureUrl")
				.IsRequired(false);
		}
	}
}