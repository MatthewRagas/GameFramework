﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{    
    enum Direction
    {
        North,
        South,
        East,
        West
    }

    class Room : Scene
    {        

        private Room _north;
        private Room _south;
        private Room _east;
        private Room _west;

        public Room() : this(12,6)
        {

        }

        public Room(int sizeX, int sizeY) : base(sizeX, sizeY)
        {

        }

        public Room North
        {
            get
            {
                return _north;
            }
            set
            {      
                if(value!=null)
                {
                    //Connect the Rooms both ways
                    value._south = this;
                }
                _north = value;                
            }
        }

        public Room South
        {
            get
            {
                return _south;
            }
            set
            {
                if (value != null)
                {
                    //Connect the Rooms both ways
                    value._north = this;
                }
                _south = value;                
            }
        }

        public Room West
        {
            get
            {
                return _west;
            }
            set
            {
                if (value != null)
                {
                    //Connect the Rooms both ways
                    value._east = this;
                }
                _west = value;                
            }
        }

        public Room East
        {
            get
            {
                return _east;
            }
            set
            {
                if (value != null)
                {
                    //Connect the Rooms both ways
                    value._west = this;
                }
                _east = value;
            }
        }

    }
}
