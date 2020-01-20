using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;

using AIM.Core;

namespace AIM.GH
{
    public class RotationComponent : GH_Component
    {

        public RotationComponent()
          : base("Rotation", "Rotation",
              "Define a rotation transformation",
              "AIM", "Elements")
        {}

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Plane", "P", "Rotation Plane", GH_ParamAccess.item);
            pManager.AddNumberParameter("Angle", "A", "Rotation Angle", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Transformation", "Transformation", "Transformation", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane rotationPlane = new Plane();
            double rotationAngle = 0;

            DA.GetData(0, ref rotationPlane);
            DA.GetData(1, ref rotationAngle);

            Transformation transformation = new Transformation(rotationPlane, rotationAngle);

            DA.SetData(0, transformation);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.RotationIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("2787a2fc-036c-4da1-b241-43045f831192"); }
        }
    }
}