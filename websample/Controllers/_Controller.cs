using System;
using Util;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class _Controller : Controller
	{
        public _Controller()
        {
            SValue = new Controllers._Controller.SessionValue(this);    
        }
        protected SessionValue SValue;

        public class SessionValue
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

            public SessionValue(_Controller p)
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





