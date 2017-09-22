using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQuiz.model
{
    class Order
    {
        public Header Header { get; set; }
        public List<LineItem> Items { get; set; }
    }
}
