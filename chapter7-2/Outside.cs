using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter7_2
{
    class Outside : Location
    {
        private bool Hot { get; set; }

        public Outside(string name, bool hot) : base(name)
        {
            Hot = hot;
        }

    }
}
