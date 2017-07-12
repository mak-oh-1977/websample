using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace websample.Tests
{
    [TestClass]
    public static class DataDirectoryInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var replace = directory.Replace(@"webapp.Tests\bin\Debug", string.Empty);
            var combine = Path.Combine(replace, @"websample\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", combine);
        }
    }
}
