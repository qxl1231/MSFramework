using System;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot.ClientAggregateRoot
{
	public class ClientUser : AggregateRootBase
	{
		/// <summary>
		/// 客户ID
		/// </summary>
		private Guid _clientId;

		/// <summary>
		/// 名
		/// </summary>
		private string _firstName;

		/// <summary>
		/// 姓
		/// </summary>
		private string _lastName;

		/// <summary>
		/// 称谓
		/// </summary>
		private string _civility;

		/// <summary>
		/// 职位
		/// </summary>
		private string _title;

		/// <summary>
		/// 邮箱
		/// </summary>
		private string _email;

		/// <summary>
		/// 座机
		/// </summary>
		private string _phone;

		/// <summary>
		/// 激活状态
		/// </summary>
		private bool _active;

		/// <summary>
		/// 电话
		/// </summary>
		private string _mobile;

		/// <summary>
		/// 职位描述
		/// </summary>
		private string _titleDescription;

		/// <summary>
		/// 行业描述
		/// </summary>
		private string _industryDescription;

		/// <summary>
		/// 部门
		/// </summary>
		private string _department;

		/// <summary>
		/// 部门
		/// </summary>
		private string _departmentDescription;

		/// <summary>
		/// 打分权重
		/// </summary>
		private int _scoringPriority;


		public int ScoringPriority2
		{
			get => _scoringPriority;
			set => _scoringPriority = value;
		}
		
		public Guid GetClientId()
		{
			return _clientId;
		}

		public void SetClientId(Guid clientId)
		{
			_clientId = clientId;
		}

		public string GetFirstName()
		{
			return _firstName;
		}

		public void SetFirstName(string firstName)
		{
			_firstName = firstName;
		}

		public string GetLastName()
		{
			return _lastName;
		}

		public void SetLastName(string lastName)
		{
			_lastName = lastName;
		}

		public string GetCivility()
		{
			return _civility;
		}

		public void SetCivility(string civility)
		{
			_civility = civility;
		}

		public string GetTitle()
		{
			return _title;
		}

		public void SetTitle(string title)
		{
			_title = title;
		}

		public string GetEmail()
		{
			return _email;
		}

		public void SetEmail(string email)
		{
			_email = email;
		}

		public string GetPhone()
		{
			return _phone;
		}

		public void SetPhone(string phone)
		{
			_phone = phone;
		}

		public bool IsActive()
		{
			return _active;
		}

		public void SetActive(bool active)
		{
			_active = active;
		}

		public string GetMobile()
		{
			return _mobile;
		}

		public void SetMobile(string mobile)
		{
			_mobile = mobile;
		}

		public string GetTitleDescription()
		{
			return _titleDescription;
		}

		public void SetTitleDescription(string titleDescription)
		{
			_titleDescription = titleDescription;
		}

		public string GetIndustryDescription()
		{
			return _industryDescription;
		}

		public void SetIndustryDescription(string industryDescription)
		{
			_industryDescription = industryDescription;
		}

		public string GetDepartment()
		{
			return _department;
		}

		public void SetDepartment(string department)
		{
			_department = department;
		}

		public string GetDepartmentDescription()
		{
			return _departmentDescription;
		}

		public void SetDepartmentDescription(string departmentDescription)
		{
			_departmentDescription = departmentDescription;
		}

		public int GetScoringPriority()
		{
			return _scoringPriority;
		}

	}
}