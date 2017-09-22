using System;
using System.Collections.Generic;
using VSQuiz.model;

namespace VSQuiz.factory
{
    internal class OrderFactory
    {
        /// <summary>
        /// Simple method to generate the collection of orders.  This is kinda wonky.  I normally would use something more robust and mantainable to do this sort of thing, like using DI and a IoC container to inject 
        /// this list of objects.  Not sure if you're looking for something like that in this quick little test.
        /// </summary>
        /// <returns></returns>
        public static List<Order> CreateOrders()
        {
            var retList = new List<Order>() {
                // order1 - client1
                new Order()
                {
                    Header= new Header() { ClientName="Client 1", Id=Guid.NewGuid()},
                    Items=new List<LineItem>() {
                        new LineItem() { Id=1,Name="Item 1", Charges=100, Date=new DateTime(2017,2,21)},
                        new LineItem() { Id=2,Name="Item 2", Charges=200, Date=new DateTime(2017,2,22)},
                        new LineItem() { Id=3,Name="Item 3", Charges=300, Date=new DateTime(2017,2,23)}
                    }
                },
                 // order2 - client2
                new Order()
                {
                    Header= new Header() { ClientName="Client 2", Id=Guid.NewGuid()},
                    Items=new List<LineItem>() {
                        new LineItem() { Id=1,Name="Item 3", Charges=300, Date=new DateTime(2017,2,23)},
                        new LineItem() { Id=2,Name="Item 4", Charges=400, Date=new DateTime(2017,2,24)},
                        new LineItem() { Id=3,Name="Item 5", Charges=500, Date=new DateTime(2017,2,25)}
                    }
                },
                 // order3 - client3
                new Order()
                {
                    Header= new Header() { ClientName="Client 3", Id=Guid.NewGuid()},
                    Items=new List<LineItem>() {
                        new LineItem() { Id=1,Name="Item 2", Charges=200, Date=new DateTime(2017,2,22)},
                        new LineItem() { Id=2,Name="Item 4", Charges=400, Date=new DateTime(2017,2,24)}
                    }
                }
            };
            return retList;
        }


        


    }
}
