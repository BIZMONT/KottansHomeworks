using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Citizens.Tests
{
    [TestClass]
    public class CitizenTests : TestsBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithInvalidGender_ThrowsArgumentOutOfRangeException()
        {
            var citizen = new CitizenOfUkraine("Roger", "Pierce", SystemDateTime.Now(), (Gender)2);
        }

        [TestMethod]
        public void Constructor_WithInvalidNameCasing_CorrectsNameToLowerCaseWithCapital()
        {
            var citizen = new CitizenOfUkraine("RoGer", "pIERCE", SystemDateTime.Now(), Gender.Male);
            Assert.AreEqual("Roger", citizen.FirstName);
            Assert.AreEqual("Pierce", citizen.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithDateGreaterThanNow_ThrowsArgumentException()
        {
            var future = this.TestTodayDate.AddDays(1);
            var citizen = new CitizenOfUkraine("Roger", "Pierce", future, Gender.Male);
        }

        [TestMethod]
        public void Constructor_WithDateTime_StoresDateOnly()
        {
            var dateAndTime = new DateTime(1991, 8, 24, 9, 30, 0);
            var dateOnly = dateAndTime.Date;
            var citizen = new CitizenOfUkraine("Roger", "Pierce", dateAndTime, Gender.Male);

            Assert.AreEqual(dateOnly, citizen.BirthDate);
        }

        // Additional test
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void VatId_WhenSetInvalidVatId_ThrowsFormatException()
        {
            var citizen = new CitizenOfUkraine("Roger", "Pierce", SystemDateTime.Now(), Gender.Male);
            citizen.VatId = "0123456789";
        }
    }
}
