namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {


        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("BMW", "23M", 3.6, 40.4);
        }

        [Test]
        public void ConstructorWorks()
        {
            string expectedMake = "BMW";
            string expectedModel = "23M";
            double expectedFuelConsuption = 3.6;
            double expectedCapacity = 40.4;

            Assert.AreEqual(expectedCapacity, car.FuelCapacity);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsuption, car.FuelConsumption);


        }


        [TestCase(null)]
        [TestCase("")]
        public void MakeShouldThrowExWhenNullOrEmpty(string input)
        {
            Assert.Throws<ArgumentException>(() => { Car d = new Car(input, "f", 1, 1); });


        }



        [TestCase(null)]
        [TestCase("")]
        public void ModelShouldThrowExWhenNullOrEmpty(string input)
        {
            Assert.Throws<ArgumentException>(() => { Car d = new Car("d", input, 1, 1); });


        }


        [TestCase(0)]
        [TestCase(-1.1)]
        public void ConsumptionlShouldThrowExWhen0OrNegative(double input)
        {
            Assert.Throws<ArgumentException>(() => { Car d = new Car("d", "f", input, 1); });


        }


        [TestCase(0)]
        [TestCase(-1.1)]
        public void CapacityShouldThrowExWhen0OrNegative(double input)
        {
            Assert.Throws<ArgumentException>(() => { Car d = new Car("d", "f", 1, input); });


        }


        [TestCase(0)]
        [TestCase(-1.1)]
        public void RefuelShouldThorwAnExWhenInputIsOOrNegeative(double input)
        {
            Assert.Throws<ArgumentException>(() => { car.Refuel(input); });


        }


        [Test]
        public void RefuelWorksWhenInputIsBelowTheCapacity()
        {
            car.Refuel(10);

            double expected = 10;
            double actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void RefuelWhenInputIsAboveTheCapacity()
        {
            car.Refuel(100);

            double expected = car.FuelCapacity;
            double actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void DriveShouldThrowExWhenCarCan_NotDriveTheInput()
        {
            Assert.Throws<InvalidOperationException>(() => { car.Drive(10000); });

        }

        [Test]
        public void DriveWorks()
        {
            car.Refuel(20);
            car.Drive(3);

            double expected = 20-0.108;
            double actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }
    }


}