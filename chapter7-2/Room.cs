﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter7_2
{
    class Room : Location
    {
        public Room(string name, string decoration) : base(name)
        {
            this.decoration = decoration;
        }

        private string decoration { get; set; }
    }
}
