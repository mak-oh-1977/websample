﻿using Microsoft.VisualBasic;
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
            public short type { get; set; }
        }

        public User CheckLogin(string id, string pass)
        {
            User ret = db.users.
                    Where(x => x.loginid == id && x.password == pass).
                    Select((x) => new User
                    {
                        name = x.name,
                        type = x.type,
                    }).FirstOrDefault();

            return ret;
        }

        public object GetUsers()
        {
            var ret = db.users.
                    Where(x => x.name != null).
                    Select((x) => new
                    {
                        x.Id,
                        x.name,
                    }).ToList();

            return ret.Select((x) => new User()
            {
                id = x.Id,
                name = x.name,
                kana = ConvToDate(x.name)
            });

        }

        public string ConvToDate(string s)
        {
            return s;
//            return s.Substring(0, 2) + "/" + s.Substring(2, 2);
        }
    }
}