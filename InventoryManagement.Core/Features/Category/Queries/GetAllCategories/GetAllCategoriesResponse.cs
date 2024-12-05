using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
  
    }

   
}
