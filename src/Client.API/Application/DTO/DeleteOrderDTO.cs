﻿using System;

namespace Ordering.API.Application.DTO
{
	public class DeleteOrderDto
	{
		public Guid OrderId { get; set; }
		public long Version { get; set; }
	}
}
