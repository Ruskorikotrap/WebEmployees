using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebEmployees.Domain.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Personnel Number")]
        public int PersonnelNumber {get;set;}
        [Display(Name = "Staff Member")]
        public bool StaffMember { get; set; }
        [Display(Name = "Full Name")]
        public string FullName {get;set;}
        [Display(Name = "Gender")]
        [Required]
        public virtual int GenderId { get; set; }

        [EnumDataType(typeof(Genders))]
        public Genders Gender
        {
            get
            {
                return (Genders)this.GenderId;
            }
            set
            {
                GenderId = (int)value;
            }
        }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
    }
    public enum Genders
    {
        Male = 1,
        Famele = 2
    }
}
