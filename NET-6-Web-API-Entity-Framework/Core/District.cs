using NET_6_Web_API_Entity_Framework.Model;
using ProductProje.API.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET_6_Web_API_Entity_Framework.Core
{
    public class District
         : Entity<int>
    {

        public string Name { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
     
    }
}
