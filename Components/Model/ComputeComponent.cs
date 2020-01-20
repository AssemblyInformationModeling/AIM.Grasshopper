/*
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace AIM.GH
{
    public class ComputeComponent : GH_Component
    {
        public ComputeComponent()
          : base("Compute Model", "Compute Model",
              "Compute an Assembly Digital Model",
              "AIM", "Assembly Digital Model")
        {
            this.Message = "WIP_v0.1";
        }
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "Model", "Model to be computed", GH_ParamAccess.item);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output", "Output", "Computation Output", GH_ParamAccess.item);
            pManager.AddGenericParameter("Issues", "Issues", "Detected Issues", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.ComputeIcon;
            }
        }
        
        public override Guid ComponentGuid
        {
            get { return new Guid("dd2c0805-6b51-41c7-a433-79974df3b4f6"); }
        }
    }
}
*/