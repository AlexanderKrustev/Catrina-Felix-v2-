namespace Entities.Deals
{
    using Entities.Account;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Deal
    {
        private decimal sumInEuro;
        private decimal sumInUSD;

        public Deal()
        {

        }

        [Key]
        public int Key { get; set; }

        public string OrderNumber { get; set; }

        public bool Reexport { get; set; }

        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        public int ConsigneeId { get; set; }
        public virtual Consignee Consignee { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int FormulationId { get; set; }
        public Formulation Formulation { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int PortId { get; set; }
        public Port Port { get; set; }

        public int TransportCompanyId { get; set; }
        public TransportCompany TransportCompany { get; set; }

        public DateTime ExpeditionDate { get; set; }

        public User Author { get; set; }       

        public string InvoiceNumber { get; set; }

        public string InkasoAkrNumber { get; set; }

        public string ClinetOrderId { get; set; }

        public string ZN_MN { get; set; }

        public string DestinationPort { get; set; }

        public decimal Quantity { get; set; }

        public decimal PricePerKg { get; set; }

        public string Currency { get; set; }

        public decimal CR { get; set; }

        public decimal SumInEuro { get; set; }

        public decimal SumInUSD { get; set; }

        public string ViaPort { get; set; }

        public string CreditTerms { get; set; }

        //public DateTime DueDate { get; set; } //TODO: DUE DATE AV+AZ

        public decimal Frei { get; set; }

        public string FreiCurrency { get; set; }

        public string InsCurrency { get; set; }

        public decimal Insurance { get; set; }

        public string TypeOfTransport { get; set; }

        public int TransportUnit { get; set; }

        public string TransportNumber { get; set; }

        public string TransportDoc { get; set; }

        public DateTime DateBL { get; set; }

        public DateTime ETD { get; set; }

        public DateTime ETA { get; set; }

        public int TransportDays { get; set; }

    }
}
