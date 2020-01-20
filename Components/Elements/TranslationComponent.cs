using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using AIM.Core;

namespace AIM.GH
{
    public class TranslationComponent : GH_Component
    {

        public TranslationComponent()
          : base("Translation", "T",
              "Create a translation transformation",
              "AIM", "Elements")
        {}
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("Vector", "Vector", "Translation Vector", GH_ParamAccess.item);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Transformation", "Transformation", "Transformation", GH_ParamAccess.item);
        }
        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Vector3d translationVector = new Vector3d();

            DA.GetData(0, ref translationVector);

            Transformation transformation = new Transformation(translationVector);

            DA.SetData(0, transformation);
            
        }
        
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.TranslationIcon;
            }
        }
        
        public override Guid ComponentGuid
        {
            get { return new Guid("cfdae639-1d64-4724-bc1b-46669015732c"); }
        }
    }
}