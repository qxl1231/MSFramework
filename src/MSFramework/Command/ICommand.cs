using System;

namespace MSFramework.Command
{
	public interface ICommand
	{
		Guid Id { get; set; }
		
		int ExpectedVersion { get; set; }
	}
}