namespace Entities.Deals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TransportCompany
    {
        [Key]
        public int Key { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
