using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiCustomerServiceSystem.Models
{
	public class IssueState
	{
		public const string OPEN = "Open";
		public const string WAITING_ME = "Waiting on Me";
		public const string WAITING_THEM = "Waiting on Them";
		public const string CLOSED = "Closed";
	}
}