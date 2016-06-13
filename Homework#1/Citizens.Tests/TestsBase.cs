using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Citizens.Tests
{
    public class TestsBase
    {
        protected readonly DateTime TestTodayDate = DateTime.UtcNow;

        [TestInitialize]
        public virtual void Initialize()
        {
            SystemDateTime.Now = () => this.TestTodayDate;
        }
    }
}