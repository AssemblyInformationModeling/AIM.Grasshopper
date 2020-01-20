using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace AIM.GH
{
    public class IntersectionStatusComponent : GH_Component
    {
        public IntersectionStatusComponent()
          : base("Intersection Status", "Intersection Status",
              "Return the intersection status of two breps. 0: Not intersecting || 1: Intersecting || 2: Touching",
              "AIM", "Analysis")
        {}

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Brep A", "Brep A", "First Brep", GH_ParamAccess.item);
            pManager.AddBrepParameter("Brep B", "Brep B", "Second Brep", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Touch Test", "Touch Test", "Enable Boolean intersection to check if Only Touching or real intersection - Heavy", GH_ParamAccess.item, false);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Status", "Status", "Status - 0: Not intersecting || 1: Intersecting || 2: Touching", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Brep brepA = null;
            Brep brepB = null;
            bool touchTest = false;

            DA.GetData(0, ref brepA);
            DA.GetData(1, ref brepB);
            DA.GetData(2, ref touchTest);

            int result = Geometry.GetIntersection(brepA, brepB, touchTest);

            DA.SetData(0, result);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.IntersectionIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("00dbae1a-d036-4074-ac39-885f5d5fa413"); }
        }
    }
}