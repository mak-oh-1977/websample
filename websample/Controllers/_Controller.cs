using System;
using Util;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class _Controller : Controller
	{
        public _Controller()
        {
            sv = new Controllers._Controller.SValue(this);    
        }
        protected SValue sv;

        public class SValue
        {
            private _Controller parent;
            
            private Object Get(Int32 index)
            {
                return parent.Session[index];
            }
            private Object Get(String name)
            {
                return parent.Session[name];
            }

            public SValue(_Controller p)
            {
                this.parent = p;
            }
            public String UID
            {
                get { return Cast.ToString(Get(ID.UID)); }
                set { parent.Session[ID.UID] = value; }
            }
            public class ID
            {
                public const String UID = "UID";
            }
        }
	}
}





