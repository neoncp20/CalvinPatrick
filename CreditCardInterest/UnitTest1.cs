using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CreditCardInterest
{
 
    public class Card
    {
        double interestRate;
        double balance;
        string name;

        public Card(string type, double amount, double newRate)
        {
            this.interestRate = newRate;
            this.balance = amount;
            this.name = type;
        }
        
        public double getInterest()
        {
            if(this.balance == 0)
            {
                return 0;
            }
            else
            {
                return this.interestRate * this.balance;
            }


        }

        public string getName()
        {
            return this.name;
        }
    }

    public class Person
    {
        List<Walet> Walets = new List<Walet>();

        public void addWalet(Walet newWalet)
        {
            this.Walets.Add(newWalet);
        }

        public void removeWalet(Walet oldWalet)
        {
            this.Walets.Remove(oldWalet);
        }

        public double getInterest()
        {
            double totalInterest = 0;

            foreach(Walet walet in Walets)
            {
                totalInterest += walet.getInterest();
            }

            return totalInterest;
        }
    }

    public class Walet
    {
        List<Card> Cards = new List<Card>();

        public void addCard(Card newCard)
        {
            this.Cards.Add(newCard);
        }

        public void removeCard(Card oldCard)
        {
            this.Cards.Remove(oldCard);
        }

        public double getInterest()
        {
            double totalInterest = 0;

            foreach(Card card in Cards)
            {
                totalInterest += card.getInterest();
            }

            return totalInterest;
        }

        public double getInterestByName(string cardName)
        {
            double totalInterest = 0;

            foreach(Card card in this.Cards)
            {
                if(card.getName() == cardName)
                {
                    totalInterest += card.getInterest();
                }
            }

            return totalInterest;
        }
    }

  
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Person person1 = new Person();
            Walet walet1 = new Walet();

            walet1.addCard(new Card("Visa", 100, .1));
            walet1.addCard(new Card("MC", 100, .05));
            walet1.addCard(new Card("Discover", 100, .01));

            person1.addWalet(walet1);
           
            //act
            double person1Int = person1.getInterest();
            double visaInt = walet1.getInterestByName("Visa");
            double mcInt = walet1.getInterestByName("MC");
            double discoverInt = walet1.getInterestByName("Discover");

            //assert
            double person1ExpInt = 16;
            double visaExpInt = 10;
            double mcExpInt = 5;
            double discoverExpInt = 1;

            Assert.AreEqual(person1ExpInt, person1Int);
            Assert.AreEqual(visaExpInt, visaInt);
            Assert.AreEqual(mcExpInt, mcInt);
            Assert.AreEqual(discoverExpInt, discoverInt);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Person person1 = new Person();
            Walet walet1 = new Walet();
            Walet walet2 = new Walet();

            walet1.addCard(new Card("Visa", 100, .1));
            walet1.addCard(new Card("Discover", 100, .01));
            walet2.addCard(new Card("MC", 100, .05));

            person1.addWalet(walet1);
            person1.addWalet(walet2);

            //act
            double person1Interest = person1.getInterest();
            double walet1Interest = walet1.getInterest();
            double walet2Interest = walet2.getInterest();

            //assert
            double person1ExpInt = 16;
            double walet1ExpInt = 11;
            double walet2ExpInt = 5;

            Assert.AreEqual(person1ExpInt, person1Interest);
            Assert.AreEqual(walet1ExpInt, walet1Interest);
            Assert.AreEqual(walet2ExpInt, walet2Interest);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            Person person1 = new Person();
            Person person2 = new Person();
            Walet walet1 = new Walet();
            Walet walet2 = new Walet();

            walet1.addCard(new Card("Visa", 100, .1));
            walet1.addCard(new Card("MC1", 100, .05));
            walet1.addCard(new Card("MC2", 100, .05));
            walet2.addCard(new Card("Visa", 100, .1));
            walet2.addCard(new Card("MC", 100, .05));

            person1.addWalet(walet1);
            person2.addWalet(walet2);

            //act
            double person1Interest = person1.getInterest();
            double person2Interest = person2.getInterest();
            double walet1Interest = walet1.getInterest();
            double walet2Interest = walet2.getInterest();

            //assert
            double person1ExpInt = 20;
            double person2ExpInt = 15;
            double walet1ExpInt = 20;
            double walet2ExpInt = 15;

            Assert.AreEqual(person1ExpInt, person1Interest);
            Assert.AreEqual(person2ExpInt, person2Interest);
            Assert.AreEqual(walet1ExpInt, walet1Interest);
            Assert.AreEqual(walet2ExpInt, walet2Interest);
        }
    }


}
