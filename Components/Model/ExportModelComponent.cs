/*
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace AIM.GH
{
    public class ExportModelComponent : GH_Component
    {
        public ExportModelComponent()
          : base("Export Model", "Export Model",
              "Export the model to .adm file",
              "AIM", "Assembly Digital Model")
        {
            this.Message = "WIP_v0.1";
            
        }
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "Model", "Model to be exported", GH_ParamAccess.item);
            pManager.AddTextParameter("Path", "Path", "Path to Save the ADM", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Save", "Save", "Save to target path", GH_ParamAccess.item);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output", "Output", "Export Output", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.ExportModelIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("ee78c35c-3cf6-45a5-a9e7-0e5a6bf14d13"); }
        }
    }
}
*/