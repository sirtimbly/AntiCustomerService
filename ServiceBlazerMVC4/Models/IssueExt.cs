using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceBlazerMVC4.Models
{
	[MetadataType(typeof(IssueMetaData))]
	public partial class Issue
	{

	}

	public class IssueMetaData
	{
		[DataType(DataType.MultilineText)]
		public string Details { get; set; }


	}
}