using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Contracts
{
	public class HeaderContract
	{
		public HttpStatusCode Code { get; set; }
		public string Message { get; set; } = null!;
	}
}
