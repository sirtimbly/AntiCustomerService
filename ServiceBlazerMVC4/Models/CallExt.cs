using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceBlazerMVC4.Models
{

	[MetadataType(typeof(CallMetaData))]
	public partial class Call
	{
	
	}

	public class CallMetaData
	{
		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }
		[DataType(DataType.MultilineText)]
		public string Promises { get; set; }
		[DataType(DataType.MultilineText)]
		public string Resolution { get; set; }
	}


}