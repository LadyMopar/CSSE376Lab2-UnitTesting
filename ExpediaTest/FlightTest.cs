using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(15, 03, 02), new DateTime(15, 03, 09), 1200);
            Assert.IsNotNull(target.Miles);
        }

        [Test()]
        public void TestGetBasePriceOneDaySpread()
        {
            var target = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 11), 700);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestGetMilesOfFlight()
        {
            var target = new Flight(new DateTime(15, 12, 12), new DateTime(15, 12, 24), 1500);
            Assert.AreEqual(target.Miles, 1500);
        }


        [Test()]
        public void TestGetBasePriceOneWeekSpread()
        {
            var target = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            Assert.AreEqual(340, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadRange()
        {
            new Flight(new DateTime(15, 11, 18), new DateTime(15, 11, 15), 100);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatCantUseNegativeMiles()
        {
            new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), -1700);
        }

        [Test()]
        public void CheckAndSeeIfFlightsAreEqual()
        {
            var flight1 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            var flight2 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            Assert.AreEqual(flight1, flight2);
        }

        [Test()]
        public void CheckAndSeeIfFlightsAreSimilarButNotSameObject()
        {
            var flight1 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            var flight2 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            Assert.AreNotSame(flight1, flight2);
        }

        [Test()]
        public void CheckIfOverriddenEqualsFunctiomWorksForTrue()
        {
            var flight1 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            var flight2 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            Assert.True(flight1.Equals(flight2));
        }

        [Test()]
        public void CheckIfOverriddenEqualsFunctiomWorksForFalse()
        {
            var flight1 = new Flight(new DateTime(15, 04, 11), new DateTime(15, 04, 17), 1700);
            var flight2 = new Flight(new DateTime(15, 04, 10), new DateTime(15, 04, 17), 1700);
            Assert.False(flight1.Equals(flight2));
        }

	}
}
