using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entites
{
	public abstract class EntityBase : IEntityBase
	{
		public virtual int Id { get; set; } 
	}
}
