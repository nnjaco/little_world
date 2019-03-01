using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using charly_world.Managers;
using charly_world.Models;

namespace charly_world.Sprites
{
    class Charly
    {


        public Input Input;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;

        public override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Left)) { Velocity.X = -Speed; }
                else if (Keyboard.GetState().IsKeyDown(Input.Right)) { Velocity.X = +Speed; }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = +Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Left)) { Velocity.X = -Speed; }
                else if (Keyboard.GetState().IsKeyDown(Input.Right)) { Velocity.X = +Speed; }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Up)) { Velocity.Y = -Speed; }
                else if (Keyboard.GetState().IsKeyDown(Input.Down)) { Velocity.Y = +Speed; }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = +Speed;
                if (Keyboard.GetState().IsKeyDown(Input.Up)) { Velocity.Y = -Speed; }
                else if (Keyboard.GetState().IsKeyDown(Input.Down)) { Velocity.Y = +Speed; }
            }
        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }
    }
}
