using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PORTIMAGES.Application.Admin.DTOs
{
    public class PortRequestDTO
    {
        public long ID { get; set; }
        public string? PortName { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
