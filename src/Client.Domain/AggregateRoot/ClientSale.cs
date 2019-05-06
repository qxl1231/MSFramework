using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientSale : ValueObject
	{
		/// <summary>
		/// 姓
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// 名
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// 职位
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool IsDeleted { get; set; }

		public string PhoneNumber { get; set; }

		private ClientSale()
		{
		}

		/// <summary>
		/// 手机
		/// </summary>
		public ClientSale(string firstName, string lastName, string title, string email, bool isDeleted,
			string phoneNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			Title = title;
			Email = email;
			IsDeleted = isDeleted;
			PhoneNumber = phoneNumber;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			// Using a yield return statement to return each element one at a time
			yield return FirstName;
			yield return LastName;
			yield return Title;
			yield return Email;
			yield return IsDeleted;
			yield return PhoneNumber;
		}
	}
}