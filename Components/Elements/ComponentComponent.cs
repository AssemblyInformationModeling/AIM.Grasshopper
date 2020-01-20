using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using AIM.Core;

using System.Windows.Forms;

namespace AIM.GH
{
    public class ComponentComponent : GH_Component
    {
        public ComponentComponent()
          : base("Component", "Component",
              "Define a component",
              "AIM", "Elements")
        { }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Elements", "Elements", "Elements in Order", GH_ParamAccess.list);
            pManager.AddGenericParameter("Transformations", "Transformations", "Transformations Sequence", GH_ParamAccess.list);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Component", "Component", "Component", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Element> inputElements = new List<Element>();
            List<Transformation> compTransformations = new List<Transformation>();

            Component outputComponent = new Component();

            DA.GetDataList(0, inputElements);
            DA.GetDataList(1, compTransformations);

            if (inputElements.Count == 1) // We have a one element component
            {
                //MessageBox.Show(inputElements[0].ToString());
                //MessageBox.Show(inputElements[0].GetType().ToString());

                if (inputElements[0] is AIM.Core.Part)
                {
                    outputComponent = new Component((Part)inputElements[0]);
                }
                else if (inputElements[0] is AIM.Core.Fastener)
                {
                    outputComponent = new Component((Fastener)inputElements[0]);
                }
                else
                {
                    throw new Exception("Unexpected Element Type!");
                }

            }
            else // We have a lot of elements in one component
            {
                foreach (object element in inputElements)
                {
                    if (element is AIM.Core.Part || element is AIM.Core.Fastener)
                    {
                        outputComponent.Add((Element)element);
                    }
                    else
                    {
                        throw new Exception("Unexpected Element Type!");
                    }
                }
            }

            outputComponent.SetTransformations(compTransformations);

            DA.SetData(0, outputComponent);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.ComponentIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("d54c2d99-a3c7-4889-9577-05e23412bc92"); }
        }
    }
}