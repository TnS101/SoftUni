namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;
   
    public class SpaceshipTests
    {
        private Spaceship space;
        
        public SpaceshipTests()
        {
            this.space = new Spaceship("space",69);
        }
        [Test]
        public void Space_Name_Should_Be_Handled_Succesfuly()
        {
            string actual = space.Name;

            string expected = "space";

            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void Space_Name_Should_Throw_Exception_If_Null()
        {
            this.space = new Spaceship("space", 69);
            Assert.Throws<ArgumentNullException>(()=>space = new Spaceship(null,69));
        }
        [Test]
        public void Space_Capacity_Should_Be_Handled_Succesfuly()
        {
            int actual = this.space.Capacity;
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Space_Capacity_Should_Throw_Exception_If_Capacity_Is_Less_Than_Zero()
        {
            this.space = new Spaceship("space", 2);
            Assert.Throws<ArgumentException>(()=>space = new Spaceship("space",-1));
        }
        [Test]
        public void Add_Astronaut_Should_Be_Handled_Succesfuly()
        {
            Astronaut ast = new Astronaut("pesho", 100);
            this.space.Add(ast);
        }
        [Test]
        public void Add_Astronaut_Should_Throw_Exception_If_Capacity_Limit_Is_Reached()
        {
            this.space = new Spaceship("space", 2);
            Astronaut ast1 = new Astronaut("pesho", 100);
            Astronaut ast2 = new Astronaut("gosho", 100);
            Astronaut ast3 = new Astronaut("ivan", 100);
            this.space.Add(ast1);
            this.space.Add(ast2);
            Assert.Throws<InvalidOperationException>(()=>this.space.Add(ast3));
        }
        [Test]
        public void Add_Astronaut_Should_Throw_Exception_If_Astronaut_Already_Exists()
        {
            this.space = new Spaceship("space", 2);
            Astronaut ast1 = new Astronaut("pesho", 100);
            Astronaut ast2 = new Astronaut("gosho", 100);
            Astronaut ast3 = new Astronaut("ivan", 100);
            this.space.Add(ast1);
            Assert.Throws<InvalidOperationException>(() => this.space.Add(ast1));
        }
        [Test]
        public void Remove_Should_Be_Handled_Succesfuly()
        {
            Astronaut ast1 = new Astronaut("pesho", 100);
           
            bool actual = this.space.Remove(ast1.Name);

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}