using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Citizens.Tests
{
    public class TestsBase
    {
        protected readonly DateTime TestTodayDate = DateTime.Now;

        [TestInitialize]
        public virtual void Initialize()
        {
            SystemDateTime.Now = () => this.TestTodayDate;
        }
    }
}