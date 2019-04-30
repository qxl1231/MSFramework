using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using Client.Domain.AggregateRoot;

namespace Client.Infrastructure.EntityConfigurations
{
	public class ClientUserEntityTypeConfiguration : EntityTypeConfigurationBase<ClientUser>
	{
		public override Type DbContextType => typeof(ClientContext);

		public override void Configure(EntityTypeBuilder<ClientUser> clientUserConfiguration)
		{
			clientUserConfiguration.HasKey(o => o.Id);

			clientUserConfiguration.Property<DateTime>("CreationTime").IsRequired();

			clientUserConfiguration.Property<Guid>("ClientId").IsRequired();

			clientUserConfiguration.Property<string>("FirstName").IsRequired();

			clientUserConfiguration.Property<string>("LastName").IsRequired();

			clientUserConfiguration.Property<string>("Civility").IsRequired();

			clientUserConfiguration.Property<string>("Title").IsRequired();

			clientUserConfiguration.Property<string>("Email").IsRequired();

			clientUserConfiguration.Property<string>("Phone").IsRequired(false);

			clientUserConfiguration.Property<bool>("Active").IsRequired();

			clientUserConfiguration.Property<string>("Mobile").IsRequired();

			clientUserConfiguration.Property<string>("TitleDescription").IsRequired();

			clientUserConfiguration.Property<string>("IndustryDescription").IsRequired();

			clientUserConfiguration.Property<string>("Department").IsRequired();

			clientUserConfiguration.Property<string>("DepartmentDescription").IsRequired(false);

			clientUserConfiguration.Property<int>("ScoringPriority").IsRequired(false);
		}
	}
}