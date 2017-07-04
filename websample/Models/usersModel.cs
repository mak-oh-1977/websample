using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websample.Models
{
    public class SampleModel
    {
        private testEntities db = new testEntities();

        public class User {
            public int id { get; set;  }
            public string name { get; set; }
            public string kana { get; set; }
            public string tel { get; set; }
        }

        public object GetUsers()
        {
            var ret = db.users.
                    Where(x => x.password == null).
                    Select((x) => new
                    {
                        x.id,
                        x.name,
                        x.kana
                    }).ToList();

            return ret.Select((x) => new User()
            {
                id = x.id,
                name = ConvToDate(x.kana),
                kana = x.kana
            });

        }

        public string ConvToDate(string s)
        {
            return s;
//            return s.Substring(0, 2) + "/" + s.Substring(2, 2);
        }
    }
}