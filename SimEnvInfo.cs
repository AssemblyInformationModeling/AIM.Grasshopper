using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace AIM
{
    public class AIMInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Assembly Information Modeling";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("dd39c5db-5b66-4508-9b5d-e3ca3fbbfcc8");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "KADK";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "alha@kadk.dk";
            }
        }
    }
}
