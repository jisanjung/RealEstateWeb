using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    [Serializable]
    public class Room
    {
        private string room_type;
        private int length;
        private int width;

        public Room()
        {

        }
        public Room(string room_type, int length, int width)
        {
            this.room_type = room_type;
            this.length = length;
            this.width = width;
        }
        public string RoomType
        {
            get { return this.room_type; }
            set { this.room_type = value; }
        }
        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
    }
}
