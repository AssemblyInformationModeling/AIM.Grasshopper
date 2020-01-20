using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;


namespace AIM.GH
{
    public class Geometry
    {
        /// <summary>
        /// Get the intersection status between two Breps
        /// </summary>
        /// <param name="firstBrep">First Brep</param>
        /// <param name="secondBrep">Second Brep</param>
        /// <param name="checkTouching">Enable Boolean intersection to check if Only Touching or real intersection - Heavy</param>
        /// <returns>0: No Intersection - 1: Intersection - 2: Touching</returns>
        public static int GetIntersection(Brep firstBrep, Brep secondBrep, bool checkTouching)
        {
            Curve[] outCurve;
            Point3d[] outPoints;
            Rhino.Geometry.Intersect.Intersection.BrepBrep(firstBrep, secondBrep, Rhino.RhinoMath.ZeroTolerance, out outCurve, out outPoints);

            List<Point3d> allPoints = new List<Point3d>();

            if (outCurve.Count() == 0)
            {
                return 0; // There is no intersection
            }
            else // Check if it is a proper intersection or just touching
            {
                if (!checkTouching)
                {
                    return 1;
                }
                else
                {
                    Brep[] booleanOutput = Rhino.Geometry.Brep.CreateBooleanIntersection(firstBrep, secondBrep, Rhino.RhinoMath.ZeroTolerance);
                    if (booleanOutput == null)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }


        /// <summary>
        /// Convert a Brep to Mesh with Minimal Meshing Settings
        /// </summary>
        /// <param name="inputBrep"></param>
        /// <returns></returns>
        public static Mesh BrepToMesh(Brep inputBrep)
        {
            Mesh outputMesh = new Mesh();

            var meshes = Mesh.CreateFromBrep(inputBrep, MeshingParameters.Default); // TODO: Add option to choose meshing type

            if (meshes == null || meshes.Length == 0)
            {
                throw new Exception("Couldn't Convert the input Brep into Mesh!");
            }
            else
            {
                foreach (var mesh in meshes)
                {
                    outputMesh.Append(mesh);
                }
            }

            return outputMesh;
        }
    }
}
