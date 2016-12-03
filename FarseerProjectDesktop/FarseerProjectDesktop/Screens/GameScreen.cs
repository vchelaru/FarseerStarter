
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace FarseerProjectDesktop.Screens
{
    public partial class GameScreen
    {
        World world;

        Body ground;
        void CustomInitialize()
        {
            CreateFarseerWorld();

            CreateBlocks();

            CreateGround();
        }

        private void CreateFarseerWorld()
        {
            float gravity = -100;
            world = new World(new Vector2(0, gravity));
        }

        private void CreateBlocks()
        {

            float startX = -80;
            float startY = 0;
            CreateBlocks(startX, startY);

            startX = -120;
            startY = 30;
            CreateBlocks(startX, startY);

        }

        private void CreateBlocks(float startX, float startY)
        {
            int blockCount = 6;
            for (int i = 0; i < blockCount; i++)
            {
                var block = new Entities.Block();
                block.CreateFarseerPhysics(world);

                block.SetFarseerPosition(startX + i * 15f, startY + i * 40);

                BlockList.Add(block);
            }
        }

        private void CreateGround()
        {
            var frbRectangle = new AxisAlignedRectangle();
            frbRectangle.Width = 700;
            frbRectangle.Height = 13;
            frbRectangle.Y = -200;
            frbRectangle.Visible = true;

            ground = FarseerPhysics.Factories.BodyFactory.CreateRectangle(
                world, frbRectangle.Width, frbRectangle.Height, 1, new Vector2(0, -12));
            ground.Position = new Vector2(0, frbRectangle.Y);
            ground.Restitution = .7f;
            ground.SleepingAllowed = true;
            ground.IsStatic = true;
            ground.Friction = .5f;

        }

        void CustomActivity(bool firstTimeCalled)
	    {
            world.Step(TimeManager.SecondDifference);

            foreach (var block in BlockList)
            {
                block.UpdateToFarseer();
            }
        }

	    void CustomDestroy()
	    {

	    }

        static void CustomLoadStaticContent(string contentManagerName)
        {

        }

    }
}
