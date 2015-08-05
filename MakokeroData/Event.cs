namespace MakokeroData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int EventId { get; set; }

        [Display(Name = "Event Owner")]
        public int EventOwnerId { get; set; }

        [Display(Name = "Style of Function")]
        public StyleOfFunction StyleOfFunction { get; set; }

        [Display(Name = "Payment Option")]
        public PaymentOption PaymentOption { get; set; }

        [Display(Name = "Number of Guests")]
        public int NumberOfGuests { get; set; }

        [Display(Name = "Special Requirements")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string SpecialRequirements { get; set; }

        [Display(Name = "Date of Function")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Setup Time")]
        [DataType(DataType.Time)]
        public TimeSpan SetupTime { get; set; }

        [Display(Name = "Packup Time")]
        [DataType(DataType.Time)]
        public TimeSpan PackupTime { get; set; }

        public virtual EventOwner EventOwner { get; set; }
    }

    public enum StyleOfFunction
    {
        [Display(Name = "Wedding Ceremony & Reception")]
        WeddingCeremonyAndReception,
        [Display(Name = "Team Building Workshop")]
        TeamBuildingWorkshop,
        Conference,
        Seminar,
        Meeting,
        Other
    }

    public enum PaymentOption
    {
        [Display(Name = "Direct Bank Deposit")]
        DirectBankDeposit,
        [Display(Name = "Bank Transfer")]
        BankTransfer
    }
}
