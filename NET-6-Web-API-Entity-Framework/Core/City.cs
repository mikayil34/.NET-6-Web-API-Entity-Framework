using NET_6_Web_API_Entity_Framework.Core;
using NET_6_Web_API_Entity_Framework.Model;

namespace ProductProje.API.Core
{
    public class City 
         : Entity<int>
    {
         
        public string Name { get; set; }
        public virtual ICollection<District> DistrictList { get; set; }
       
    }
}
