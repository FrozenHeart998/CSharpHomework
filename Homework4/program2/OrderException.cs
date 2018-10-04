using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderException : ApplicationException
    {
        public OrderException(string messageName) : base(messageName)
        {

        }
    }
}
