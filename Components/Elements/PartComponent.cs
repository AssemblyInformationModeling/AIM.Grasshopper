using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using AIM.Core;
using System.Windows.Forms;

namespace AIM.GH
{
    public class PartComponent : GH_Component
    {

        public PartComponent()
          : base("Part", "Part",
              "Define a part",
              "AIM", "Elements")
        { }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGeometryParameter("Geometry", "Geometry", "Part Geometry", GH_ParamAccess.item);
            pManager.AddGenericParameter("Transformations", "Transformations", "Transformations Sequence", GH_ParamAccess.list);
            pManager.AddBooleanParameter("Off", "Off", "Offsite Assembly", GH_ParamAccess.item, false);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Part", "Part", "Part Definition", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            object inputGeometry = new object();
            Brep partGeometryBrep = new Brep();
            Mesh partGeometryMesh = new Mesh();
            bool isOffsite = false;

            List<Transformation> partTransformations = new List<Transformation>();

            DA.GetData(0, ref inputGeometry);
            DA.GetDataList(1, partTransformations);
            DA.GetData(2, ref isOffsite);

            Part myPart = new Part();

            myPart.isOffsite = isOffsite;

            if (inputGeometry is Grasshopper.Kernel.Types.GH_Brep) // If we have a Brep as an input, we convert it to Mesh and set both as part geometry
            {
                DA.GetData(0, ref partGeometryBrep);
                myPart.SetGeometry(partGeometryBrep, Geometry.BrepToMesh(partGeometryBrep));
            }
            else if (inputGeometry is Grasshopper.Kernel.Types.GH_Mesh) // If we got the mesh only
            {
                DA.GetData(0, ref partGeometryMesh);
                myPart.SetGeometry(partGeometryMesh);
            }
            else
            {
                throw new Exception("Geometry can be only a Brep or Mesh");
            }

            myPart.SetTransformations(partTransformations);

            DA.SetData(0, myPart);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PartIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("5cb328a1-d5f3-451d-bd66-45e3dbd2f5ca"); }
        }
    }
}
