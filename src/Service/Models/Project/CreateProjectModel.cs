using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core
{
    public class CreateProjectModel
    {
        [Required]
        public string Name { get; set; }
        public List<Guid> Users { get; set; }
    }
}
