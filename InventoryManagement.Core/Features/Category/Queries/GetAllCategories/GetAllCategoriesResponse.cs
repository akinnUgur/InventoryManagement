using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesResponse
    {
        public ICollection<Entities.Category> Categories { get; set; } 
        public GetAllCategoriesResponse()
        {
            Categories = new List<Entities.Category>();
        }
    }

   
}
