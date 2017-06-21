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

            return ret.Select((x) => new
            {
                x.id,
                name = ConvToDate(x.kana),
                //                kana = Strings.StrConv(x.kana, VbStrConv.Narrow, 0x411)
            });

        }

        public string ConvToDate(string s)
        {
            return s.Substring(0, 2) + "/" + s.Substring(2, 2);
        }
    }
}