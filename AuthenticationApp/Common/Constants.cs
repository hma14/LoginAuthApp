using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationApp.Common
{
   


    public enum MATERIALS_CATEGORY
    {
        Prototypes,
        Production,
        Both
    }

    public enum MATERIALS_TYPE
    {
        Precision_Metals,
        Precision_Plastics,
        Membrane_Switches,
        Graphic_Overlays,
        Elastomers,
        Labels,
        Other

    }
   
    public enum MATERIALS_Main_Types
    {
        Metals_Irons,
        Metals_Steels,
        Metals_Aluminums,
        Metals_Coppers,
        Metals_Titanium,
        Metals_Zincs,
        Metals_Other,

        Plastics_ABS,
        Plastics_PLA,
        Plastics_Nylon,
        Plastics_Delron,
        Plastics_Polycarbonate,
        Plastics_Polyethelene,
        Plastics_Polyester,
        Plastics_PVC,
        Plastics_Acrylic,
        Plastics_Epoxy,
        Plastics_Other,

        Membrane_Switches_MembraneSwitch,
        Membrane_Switches_HybridKeypad,

        Elastomers_OpenTextBoxForDetail,

        Labels_OpenTextBoxForDetail,

        Other_MilledStone,
        Other_MilledWood,
        Other_FlexCircuits,
        Other_CableAssemblies
    }

    public enum MATERIALS_Processes
    {
        None,
        Metals_Machined,
        Metals_Cast,
        Metals_CastAndMachined,
        Metals_Extruded,
        Metals_ExtrudedAndMachined,

        Plastics_InjectionMold_1Shot,
        Plastics_InjectionMold_MultiShot,
        Plastics_InjectionMolt_Overmold,
        //o   Query overmold material
        Plastics_Machined,
        Plastics_Printed3D,
        Plastics_Extruded,
        Plastics_ExtrudedAndMachined,


    }

    public enum MATERIALS_TYPE_Precision_Metals_Surface_Finish
    {
        None,
        Metals_None,
        Metals_PowderCoat,
        Metals_Paint,
        Metals_AnodizedAluminium,
        Metals_HardAnodizedAluminium,
        Metals_Plated
    }

   
    public enum MATERIALS_TYPE_Membrane_Switches_Attributes
    {
        None,
        SilkScreenOrDigitalPrint,
        Waterproof_Yes,
        Waterproof_No,
        Embossing_Yes,
        Embossing_No,
        LEDLighting_Yes,
        LEDLighting_No,
        LED_EL_Backlighting_Yes,
        LED_EL_Backlighting_No,
    }

    public enum MATERIALS_TYPE_Graphic_Overlays_Attributes
    {
        None,
        SilkScreenOrDigitalPrint,
        Embossing_Yes,
        Embossing_No,
        SelectiveTexture_Yes,
        SelectiveTexture_No
    }

 public enum LeadTimeFromNowInMonth
    {
        OneMonth = 1,
        TwoMonth,
        ThreeMonth, 
        FourMonth,
        FiveMonth,
        SixMonth,
        SevenMonth,
        EightMonth,
        NineMonth,
        TenMonth,
        ElevenMonth,
        OneYear,

    }



  
    public enum QUANTITY_BREAKS
    {
        OneHundred = 100,
        TwoHundred = 200,
        OneThausand = 1000,
        TwoThausand = 2000,


    }
    public enum FILE_TYPE
    {
        PDF_2D,
        STEP_3D,
        FORM_DATA
    }

    public enum USER_TYPE
    {
        Adimin,
        Customer,
        Vendor
    }

    public enum States
    {
        CreateRFQ = 1,
        PendingRFQ,
        OutForRFQ,
        BackFromRFQ,
        RFQRevision,
        RFQCancelled,
        QuoteAccepted,
        OrderInitiated,
        OrderPaid,
        ProofingStarted,
        ProofingComplete,
        ProofApproved,
        ProofRejected,
        ToolingStarted,
        SampleComplete,
        SampleApproved,
        SampleRejected,
        ProductionStarted,
        ProductionComplete
    }

}