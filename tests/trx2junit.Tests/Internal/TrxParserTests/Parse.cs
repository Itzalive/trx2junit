﻿using System.Xml.Linq;
using NUnit.Framework;

namespace trx2junit.Tests.Internal.TrxParserTests
{
    [TestFixture]
    public class Parse
    {
        [Test]
        public void Parse_NUnit___OK()
        {
            Models.Test actual = this.ParseCore("./data/nunit.trx");

            Assert.IsNotNull(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Parse_NUnit_with_no_tests___OK()
        {
            Models.Test actual = this.ParseCore("./data/nunit-no-tests.trx");

            Assert.IsNotNull(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Parse_MsTest___OK()
        {
            Models.Test actual = this.ParseCore("./data/mstest.trx");

            Assert.IsNotNull(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Parse_MsTest_with_warnings___OK()
        {
            Models.Test actual = this.ParseCore("./data/mstest-warning.trx");

            Assert.IsNotNull(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Parse_XUnit___OK()
        {
            Models.Test actual = this.ParseCore("./data/xunit.trx");

            Assert.IsNotNull(actual);
        }
        //---------------------------------------------------------------------
        private Models.Test ParseCore(string fileName)
        {
            XElement trx = XElement.Load(fileName);
            var sut      = new TrxParser(trx);

            sut.Parse();

            return sut.Result;
        }
    }
}
