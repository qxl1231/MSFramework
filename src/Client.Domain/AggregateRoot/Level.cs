using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class Level : Enumeration
	{
		/// <summary>
		/// A类客户
		/// </summary>
		public static readonly Level A = new Level(1, nameof(A).ToLowerInvariant());

		/// <summary>
		/// B类客户
		/// </summary>
		public static Level B = new Level(2, nameof(B).ToLowerInvariant());
	
		/// <summary>
		/// C类客户
		/// </summary>
		public static Level C = new Level(3, nameof(C).ToLowerInvariant());

		public Level(int id, string name) : base(id, name)
		{
		}
	}
}