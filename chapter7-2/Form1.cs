using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chapter7_2
{
    public partial class Form1 : Form
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "an oak door with a brass knob");
            diningRoom = new Room("dining room", "a crystal chandelier");
            kitchen = new RoomWithDoor("kitchen", "stainless steeel appliances", "a screen door");

            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            backYard = new OutsideWithDoor("back yard", true, "a screen door");
            garden = new Outside("garden", false);

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { backYard, frontYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            comboBox1.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
                comboBox1.Items.Add(currentLocation.Exits[i].Name);
            comboBox1.SelectedIndex = 0;

            textBox1.Text = currentLocation.Description;

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[comboBox1.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }
    }
}
