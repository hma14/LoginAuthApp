using AuthenticationApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationApp.ViewModels
{
    public class TaskDataViewModel
    {
        [Key]
        public Guid TaskId { get; set; }
        public USER_TYPE UserType { get; set; }
        public int PartNumberRevision { get; set; }
        public MATERIALS_CATEGORY MaterialCategory { get; set; }
        public MATERIALS_TYPE Material { get; set; }
        public MATERIALS_Main_Types MaterialMainType { get; set; }
        public MATERIALS_Processes Process { get; set; }
        public MATERIALS_TYPE_Precision_Metals_Surface_Finish SurfaceFinish { get; set; }
        public MATERIALS_TYPE_Membrane_Switches_Attributes SwitchesAttributes { get; set; }
        public MATERIALS_TYPE_Graphic_Overlays_Attributes OverlaysAttributes { get; set; }
        public QUANTITY_BREAKS QuantityBreak { get; set; }
        public LeadTimeFromNowInMonth LeadTime { get; set; }
        public FILE_TYPE FileType { get; set; }


    }
}