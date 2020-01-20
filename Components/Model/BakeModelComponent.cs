/*
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace AIM.GH
{
    public class BakeModelComponent : GH_Component
    {

        public BakeModelComponent()
          : base("Bake Model", "Bake Model",
              "Extract all geometry from an Assembly Digital Model at the start or end of the assembly",
              "AIM", "Assembly Digital Model")
        {
            this.Message = "WIP_v0.1";
        }
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "Model", "Model to be computed", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Start", "Start", "Bake the geometry at the Start", GH_ParamAccess.item);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Model Geometry", "Model Geometry", "Complete model geometry", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.BakeIcon;
            }
        }
        
        public override Guid ComponentGuid
        {
            get { return new Guid("2a4d8ea8-9843-478f-96fa-e51f59ff7d77"); }
        }
    }
}
*/