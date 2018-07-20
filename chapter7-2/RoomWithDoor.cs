using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter7_2
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public string DoorDescription => throw new NotImplementedException();

        public Location DoorLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
