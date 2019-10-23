﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {
        private Direction _facing;

        public Enemy() : this('E')
        {

        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        public void Move()
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveRight();
                    break;
                case Direction.West:
                    MoveLeft();
                    break;
            }

        }

        private void MoveUp()
        {
            if (!TheScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
            else
            {
                _facing = Direction.South;
            }
        }

        private void MoveDown()
        {
            if (!TheScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
            else
            {
                _facing = Direction.North;
            }
        }

        private void MoveLeft()
        {
            if (!TheScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            else
            {
                _facing = Direction.East;
            }
        }

        private void MoveRight()
        {
            if (!TheScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            else
            {
                _facing = Direction.West;
            }
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = TheScene.GetEntities(X, Y);
            bool hit = false;
            foreach(Entity e in touched)
            {
                if(e is Player)
                {
                    hit = true;
                    break;
                }
            }

            if(hit)
            {
                TheScene.RemoveEntity(this);
            }
        }
    }
}
