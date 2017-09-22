using System;
using System.Collections.Generic;
using VSQuiz.model;

namespace VSQuiz.printer
{
    internal class Printer
    {
        /// <summary>
        /// Prints a set of orders (header line items)
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="taskTitle"></param>
        internal static void PrintOrderSetTask(List<Order> orders, string taskTitle)
        {
            Console.WriteLine(taskTitle);
            PrintEndDivider();

            orders.ForEach(o1 =>
            {
                var o = o1;
                PrintOrderHeader(o);
                PrintOrderListItems(o.Items);
            });
        }

        /// <summary>
        /// Prints a set of list of LineItem objects
        /// </summary>
        /// <param name="lineItems"></param>
        /// <param name="TaskTitle"></param>
        internal static void PrintLineItemTask(List<LineItem> lineItems, string TaskTitle)
        {
            Console.WriteLine(TaskTitle);
            PrintEndDivider();
            lineItems.ForEach(li => Console.WriteLine(string.Format("   {0} | {1} | {2} | {3}", li.Id, li.Date, li.Name, li.Charges)));
            PrintEndDivider();
        }

        /// <summary>
        /// Prints a list of GroupedValues
        /// </summary>
        /// <param name="items"></param>
        /// <param name="taskTitle"></param>
        internal static void PrintGroupedValueSet(List<GroupedValue> items, string taskTitle)
        {
            PrintEndDivider();
            items.ForEach(dv => Console.WriteLine(string.Format("   {0} | {1} ", dv.Date, dv.Value)));
            PrintEndDivider();
        }

        #region helper-printer-functions
        private static void PrintEndDivider()
        {
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void PrintOrderListItems(List<LineItem> items)
        {
            items.ForEach(i1 =>
            {
                //scope a local variable to inside the closure to avoid compiler specific artifacts.
                var i = i1;
                Console.WriteLine(string.Format("   {0} | {1} | {2} | {3}", i.Id, i.Date, i.Name, i.Charges));
            });
            PrintEndDivider();
        }

        private static void PrintOrderHeader(Order order)
        {
            Console.WriteLine(string.Format("HeaderId  = {0}", order.Header.Id));
            Console.WriteLine(string.Format("ClientName = {0}", order.Header.ClientName));
        }
        #endregion
    }
}
