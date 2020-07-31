namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class SoftParkTest
    {
        private SoftPark soft;
        [SetUp]
        public void Setup()
        {
            this.soft = new SoftPark();
        }

        [Test]
        public void ParkingCar_ShouldParkCar()
        {
            string slot = "A1";
            Car car = new Car("bmw", "69");
            
            string actualMessage = soft.ParkCar(slot,car);
            string expectedMessage = $"Car:{car.RegistrationNumber} parked successfully!";
            Assert.AreEqual(expectedMessage,actualMessage);
        }
       [Test]
       public void ParkingCar_ShouldThrowException_IfSlotDoesntExist()
        {
            string slot = "A1";
            Car car = new Car("bmw", "69");
            this.soft.ParkCar("A1",car);
            Assert.Throws<ArgumentException>(()=>soft.ParkCar("",car)
            , "Parking spot doesn't exists!");
        }
        [Test]
        public void ParkingCar_ShouldThrowException_IfSlotIsTaken()
        {
            string slot = "A1";
            Car car = new Car("bmw", "69");
            this.soft.ParkCar("A1",car);
            Assert.Throws<ArgumentException>(()=>soft.ParkCar("A1",car)
            , "Parking spot is already taken!");
        }
        [Test]
        public void ParkingCar_ShouldThrowException_IfCarIsAlreadyParked()
        {
            Car car = new Car("bmw", "69");
            Car anotherCar = new Car("make", "reg");
            soft.ParkCar("A1", car);
            Assert.Throws<InvalidOperationException>(() => soft.ParkCar("A2", car) 
           , "Car is already parked!");
        } 
        [Test]
        public void RemoveCar_ShouldHandleSuccesfuly()
        {
            Car car = new Car("s", "s");
            this.soft.ParkCar("A1", car);

            string actualMessage = this.soft.RemoveCar("A1", car);

            string expectedMessage = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedMessage,actualMessage);
        }
        [Test]
        public void RemoveCar_ShouldThrowException_IfCarDoesntExist()
        {
            string slot = "A1";
            Car car = new Car("bmw", "69");
            Car otherCar = new Car("audi","50");
            Assert.Throws<ArgumentException>(()=>soft.RemoveCar(slot,otherCar)
            , "Car for that spot doesn't exists!");
        }
        [Test]
        public void RemoveCar_ShouldThrowException_IfSlotDoesntExist()
        {
            string slot = "A1";
            Car car = new Car("bmw", "69");
            Assert.Throws<ArgumentException>(()=>soft.RemoveCar("nestho si",car)
            , "Parking spot doesn't exists!");
        }
        [Test]
        public void Parking_ShouldHaveProperCount()
        {
            int actual = soft.Parking.Count;

            int expected = 12;

            Assert.AreEqual(expected,actual);
        }
    }
}