using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Temp2.Models
{
    public enum MATERIALS
    {

    }

    public enum PROCESSES
    {

    }
    public enum QUANTITY_BREAKS
    {

    }
    public enum FILE_TYPE
    {

    }
   


    public class TaskData
    {
        [Key]
        public Guid TaskId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VenderId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        [Required]
        public int PartNumberRevision { get; set; }
        [Required]
        public MATERIALS Material { get; set; }
        [Required]
        public PROCESSES Process { get; set; }
        [Required]
        public QUANTITY_BREAKS QuantityBreak { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LeadTime { get; set; }
        [Required]
        public FILE_TYPE FileType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateTC { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateTC { get; set; }
    }
}