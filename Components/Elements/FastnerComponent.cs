using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using AIM.Core;

namespace AIM.GH
{
    public class FastnerComponent : GH_Component
    {
        public FastnerComponent()
          : base("Fastner", "Fastner",
              "Define a new Fastner",
              "AIM", "Elements")
        {}
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "Geometry", "Fastner Geometry", GH_ParamAccess.item);
            pManager.AddPlaneParameter("Position", "Origin", "Manipulation Origin", GH_ParamAccess.item);
            pManager.AddNumberParameter("UMZ", "UMZ", "User Manipulation Zone", GH_ParamAccess.item, 0);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //pManager.AddGenericParameter("Fastner", "Fastner", "Fastner", GH_ParamAccess.item);
        }
        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            /*
            Brep fastenerGeometry = new Brep();
            Point3d fastenerOrigin = new Point3d();
            double umz = 0;

            DA.GetData(0, ref fastenerGeometry);
            DA.GetData(1, ref fastenerOrigin);
            DA.GetData(2, ref umz);

            //Fastener fastener = new Fastener(fastenerGeometry, fastenerOrigin, umz);

            //DA.SetData(0, fastener);
            */
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.FastenerIcon;
            }
        }
        
        public override Guid ComponentGuid
        {
            get { return new Guid("6237c71a-5d72-40d3-87d0-8ad5efa3aabb"); }
        }
    }
}