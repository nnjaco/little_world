using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charly_world.Managers;
using charly_world.Models;

namespace charly_world.Sprites
{
  public class Sprite<InterfaceObject>
  {
        public Sprite()
        {
            public object _spriteT = new Sprite<InterfaceObject>();
        }
        
        #region Fields

        protected AnimationManager _animationManager;

    protected Dictionary<string, Animation> _animations;

    protected Vector2 _position;

    protected Texture2D _texture;
        

        #endregion

        #region Properties





        #endregion

        #region Methods

        public virtual void Draw(SpriteBatch spriteBatch)
    {
      if (_texture != null)
        spriteBatch.Draw(_texture, _spriteT.Position, Color.White);
      else if (_animationManager != null)
        _animationManager.Draw(spriteBatch);
      else throw new Exception("This ain't right..!");
    }

    public virtual void Move()
    {
       

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

    public Sprite(Dictionary<string, Animation> animations)
    {
      _animations = animations;
      _animationManager = new AnimationManager(_animations.First().Value);
    }

    public Sprite(Texture2D texture)
    {
      _texture = texture;
    }

    public virtual void Update(GameTime gameTime, List<_spriteT> sprites)
    {
      

      SetAnimations();

      _animationManager.Update(gameTime);

      Position += Velocity;
      Velocity = Vector2.Zero;
    }

    #endregion
  }
}
