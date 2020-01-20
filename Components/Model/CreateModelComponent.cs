using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grasshopper.Kernel;
using Rhino.Geometry;
using AIM.Core;

namespace AIM.GH
{
    public class ModelComponent : GH_Component
    {

        public Model myModel;

        public ModelComponent()
          : base("Create Model", "Create Model",
              "Create an Assembly Digital Model",
              "AIM", "Assembly Digital Model")
        { }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Elements", "Elements", "Assembly Elements", GH_ParamAccess.list);
            pManager.AddGeometryParameter("Obstacles", "Obstacles", "Obstacles in the environment", GH_ParamAccess.list);
            pManager[1].Optional = true;

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "Model", "Assembly Digital Model", GH_ParamAccess.item);
            pManager.AddTextParameter("Log", "Log", "Model Output", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<object> inputElements = new List<object>();
            List<object> inputObstacles = new List<object>();

            DA.GetDataList(0, inputElements);
            DA.GetDataList(1, inputObstacles);

            Model outputModel = new Model();

            foreach (dynamic element in inputElements)
            {
                if (element.ToString() is "AIM.Core.Component") // couldnt figure out my way around GH object wrapper.. 
                {
                    outputModel.Add((Component)element.Value);
                }
                else if (element.ToString() is "AIM.Core.Part")
                {
                    outputModel.Add((Part)element.Value);
                }
                else
                {
                    throw new Exception("Unexpected Element Type!");
                }
            }

            foreach (dynamic obstacle in inputObstacles)
            {

                if (obstacle is Grasshopper.Kernel.Types.GH_Brep)
                {
                    Grasshopper.Kernel.Types.GH_Brep b = (Grasshopper.Kernel.Types.GH_Brep)obstacle;
                    outputModel.Add(Geometry.BrepToMesh(b.Value));
                }
                else if (obstacle is Grasshopper.Kernel.Types.GH_Mesh)
                {
                    Grasshopper.Kernel.Types.GH_Mesh m = (Grasshopper.Kernel.Types.GH_Mesh)obstacle;
                    Mesh mesh = m.Value;
                    outputModel.Add(mesh);
                }
                else
                {
                    throw new Exception("Obstacle can be only a Brep or Mesh");
                }
            }

            DA.SetData(0, outputModel);
            DA.SetData(1, Log.GetLog(outputModel));

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.CreateModelIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("79b7ee21-4992-4c1e-ae0f-2fd013095f54"); }
        }


        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            menu.Items.Add("Compute", null, menuFirstItemClicked);

            base.AppendAdditionalMenuItems(menu);
        }

        public void menuFirstItemClicked(object sender, EventArgs e)
        {
            MessageBox.Show("I will compute");
        }

    }
}