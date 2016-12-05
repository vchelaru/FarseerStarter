
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
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace FarseerProjectDesktop.Screens
{
	public partial class StackingScreen
	{
        World world;

        Body ground;
        void CustomInitialize()
		{
            Camera.Main.Y = 220;

            CreateFarseerWorld();

            CreateBlocks();

            CreateGround();

        }

        private void CreateFarseerWorld()
        {
            world = new World(Vector2.Zero);
            world.Gravity = new Vector2(0f, -100);

        }

        private void CreateBlocks()
        {
            // Note: Stacking works...somewhat.
            // If heightAboveGround is 0, the blocks
            // seem to stack and are perfectly stable.
            // Setting heightAboveGround to a non-zero value
            // destailizes the pyramid when it hits the ground.
            // Setting the value up to a larger number like 100 causes
            // it to squash quite a bit when it hits the ground, and it never
            // stabilizes afterwards.

            float heightAboveGround = 0;

            int rowCount = 14;
            float ySpacing = 32;
            // start at the bottom:
            for(int row = 0; row < rowCount; row++)
            {
                float xSpacing = 40;

                int numberOfBlocks = rowCount - row;

                float left = numberOfBlocks * -xSpacing/2.0f;

                for(int i = 0; i < numberOfBlocks; i++)
                {
                    CreateBlockAt(left + i * xSpacing, heightAboveGround + row * ySpacing + 16);
                }

            }

        }
        
        private void CreateBlockAt(float x, float y)
        {
            var block = new Entities.Block();
            block.CreateFarseerPhysics(world);
            block.SetFarseerPosition(x, y);

            BlockList.Add(block);
        }

        private void CreateGround()
        {
            var surfaceLevel = 0;

            var frbRectangle = new AxisAlignedRectangle();
            frbRectangle.Width = 700;
            frbRectangle.Height = 13;
            frbRectangle.Y = -surfaceLevel - frbRectangle.Height / 2.0f; 
            frbRectangle.Visible = true;

            ground = FarseerPhysics.Factories.BodyFactory.CreateRectangle(
                world, frbRectangle.Width, frbRectangle.Height, 1, new Vector2(0, -12));
            ground.Position = new Vector2(0, frbRectangle.Y);
            ground.Restitution = .7f;
            ground.SleepingAllowed = true;
            ground.IsStatic = true;
            ground.Friction = 5f;
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
