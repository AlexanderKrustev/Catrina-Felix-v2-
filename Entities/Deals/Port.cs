namespace Entities.Deals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Port
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
