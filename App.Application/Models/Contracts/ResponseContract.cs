using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Contracts
{
	public class ResponseContract
	{
		private HeaderContract header;
		public HeaderContract Header
		{
			get 
			{ 
				if (header is null)
				{
					header = new HeaderContract();
					header.Code = HttpStatusCode.OK;
				}
				return header; 
			}

			set 
			{ 
				header = value; 
			}
		}
	}
}
