using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Contracts
{
	public class TypedResponseContract<TData> : ResponseContract
	{
		public TData? Data { get; set; }
	}
}
