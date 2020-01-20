using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace AIM.GH
{
    public class LoadModelComponent : GH_Component
    {
        public LoadModelComponent()
          : base("Load Model", "Load",
              "Load an Assembly Digital Model",
              "AIM", "Assembly Digital Model")
        {
            this.Message = "WIP_v0.1";
        }
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Path", "Path", "Path to Save the ADM", GH_ParamAccess.item);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "Model", "Loaded Model", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.LoadIcon;
            }
        }
        
        public override Guid ComponentGuid
        {
            get { return new Guid("c6343147-cfcc-4b64-9bed-4ce6da372ae5"); }
        }
    }
}