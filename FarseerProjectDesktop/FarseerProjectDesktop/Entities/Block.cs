#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common;
using FarseerPhysics.Collision.Shapes;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace FarseerProjectDesktop.Entities
{
    public partial class Block
    {
        Body physicsBody;

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
	    {
        }

        public void CreateFarseerPhysics(World world)
        {

            physicsBody = BodyFactory.CreateRectangle(
                world, SpriteInstance.Width, SpriteInstance.Height, 1);

            // I'm not sure what "Restitution" means (not documented in Farseer .dll) but 
            // having a nonzero value destabilizes stacking. With it at 0 (default) stacking works perfectly);
            //physicsBody.Restitution = .6f;

            physicsBody.Friction = 5f;
            physicsBody.BodyType = BodyType.Dynamic;
            physicsBody.SleepingAllowed = true;

        }

        private void CustomActivity()
	    {


	    }

	    private void CustomDestroy()
	    {


	    }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        internal void SetFarseerPosition(float x, float y)
        {
            physicsBody.Position = new Vector2(x, y);
        }

        internal void UpdateToFarseer()
        {
            this.X = physicsBody.Position.X;
            this.Y = physicsBody.Position.Y;
            this.RotationZ = physicsBody.Rotation;
        }
    }
}
