namespace MakokeroData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventOwner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventOwner()
        {
            Events = new HashSet<Event>();
        }

        public int EventOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Client Name")]
        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }

        [Display(Name = "Company Name")]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Display(Name = "Position/Title")]
        [StringLength(50)]
        public string PositionTitle { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
        [Required]
        [StringLength(50)]
        public string MobilePhone { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
