﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.CategoryDtos
{
	public class GetCategoryDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public bool CategoryType { get; set; }
		public bool Status { get; set; }
	}
}
