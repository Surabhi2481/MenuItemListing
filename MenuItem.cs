using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemListing
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Free Delivery")]
        public Boolean FreeDelivery { get; set; }

        [Required]
        public double Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

        public Boolean Active { get; set; }

    }
}