using System.Collections.Generic;
using System.Linq;
using VSQuiz.factory;
using VSQuiz.model;
using VSQuiz.printer;

namespace VSQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            runTasks();
        }

        private static void runTasks()
        {
            var orders = OrderFactory.CreateOrders();
            var task1 = orders;
            List<Order> task2 = orders
                                    .Select(o => new Order()
                                    {
                                        Header = o.Header,
                                        Items = o.Items
                                                    .OrderByDescending(oi => oi.Charges)
                                                    .ToList()
                                    })
                                    .OrderByDescending(o => o.Header.ClientName)
                                    .ToList();

            var task3 = orders
                            .SelectMany(o => o.Items)
                            .OrderBy(o => o.Date)
                            .ToList();

            var task4 = orders
                            .SelectMany(o => o.Items)
                            .Where(li => li.Charges >= 300)
                            .OrderBy(li => li.Name)
                            .ToList();

            var task5 = orders
                            .SelectMany(o => o.Items)
                            .GroupBy(li => li.Date)
                            .Select(group => new GroupedValue()
                            {
                                Date = group.Key,
                                Value = group.Count()
                            })
                            .OrderBy(g => g.Date)
                            .ToList();

            var task6 = orders
                            .SelectMany(o => o.Items)
                            .GroupBy(li => li.Date)
                            .Select(group => new GroupedValue()
                            {
                                Date = group.Key,
                                Value = group.Sum(g => g.Charges)
                            })
                            .OrderBy(g => g.Date)
                            .ToList();

            Printer.PrintOrderSetTask(task1, "*** Task 1: Print orders");
            Printer.PrintOrderSetTask(task2, "*** Task 2: Print orders sorted descending by client name and line items sorted descending by Charges");

            Printer.PrintLineItemTask(task3, "*** Task3: Print lines ordered by date (ascending)");
            Printer.PrintLineItemTask(task4, "*** Task 4: Print lines sorted by LineNumber where charge is greater than or equal 300.");

            Printer.PrintGroupedValueSet(task5, "*** Task 5: Print count of line items per date.");
            Printer.PrintGroupedValueSet(task6, "*** Task 6: Print line items total charges per date.");
        }
    }
}
