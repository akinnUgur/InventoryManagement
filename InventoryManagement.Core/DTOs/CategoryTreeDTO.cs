using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.DTOs
{
    public class CategoryTreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryTreeDTO> SubCategories { get; set; } = new();
    }
}
