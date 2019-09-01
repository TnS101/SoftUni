using NUnit.Framework;
using System;
//namespace HeroRepository.Tests
//{
    public class Tests
    {
        private HeroRepository repos;
        [SetUp]
        public void Setup()
        {
            this.repos = new HeroRepository();
        }

        [Test]
        public void CreateHero_Should_HandleSuccsefuly()
        {
            Hero hero = new Hero("ic",2);
            
            string actual = this.repos.Create(hero);

            string expected = $"Successfully added hero {hero.Name} with level {hero.Level}"; ;

            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void CreateHero_Should_Throw_Exception_If_Hero_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(()=>this.repos.Create(null));
        }
        [Test]
        public void CreateHero_Should_Throw_Exception_If_Hero_Already_Exists()
        {
            Hero hero = new Hero("ic", 2);
            this.repos.Create(hero);
            Assert.Throws<InvalidOperationException>(() => repos.Create(hero));
        }
        [Test]
        public void RemoveHero_Should_Handle_Succesfuly()
        {
           
            Hero hero = new Hero("ic", 2);
            this.repos.Create(hero);
            bool actual = this.repos.Remove(hero.Name);

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveHero_Should_Throw_Exception_If_Hero_Is_Null()
        {
            Hero hero = new Hero(null, 2);
            this.repos.Create(hero);
            Assert.Throws<ArgumentNullException>(()=>this.repos.Remove(hero.Name));
        }
        [Test]
        public void GetHero_With_Highest_Stats_Should_Handle_Succesfuly()
        {
            Hero hero = new Hero("Sac", 2);
            Hero hero1 = new Hero("Jac", 1);
            this.repos.Create(hero);
            this.repos.Create(hero1);
            Hero actual = this.repos.GetHeroWithHighestLevel();
            Hero expected = hero;

            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void GetHero_Should_Handle_Succesfuly()
        {
            Hero hero = new Hero("Sack", 2);
            this.repos.Create(hero);
            Hero expected = this.repos.GetHero(hero.Name);

            Hero actual = hero;

            Assert.AreEqual(expected, actual);
        }
    }
//}