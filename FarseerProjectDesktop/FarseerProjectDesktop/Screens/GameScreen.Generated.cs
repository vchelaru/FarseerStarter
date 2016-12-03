#if ANDROID || IOS
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif

using Color = Microsoft.Xna.Framework.Color;

// Generated Usings
using FarseerProjectDesktop.Entities;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math;

namespace FarseerProjectDesktop.Screens
{
	public partial class GameScreen : FlatRedBall.Screens.Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FlatRedBall.Math.PositionedObjectList<FarseerProjectDesktop.Entities.Block> BlockList;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			BlockList = new FlatRedBall.Math.PositionedObjectList<FarseerProjectDesktop.Entities.Block>();
			BlockList.Name = "BlockList";
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				for (int i = BlockList.Count - 1; i > -1; i--)
				{
					if (i < BlockList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						BlockList[i].Activity();
					}
				}
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			
			BlockList.MakeOneWay();
			for (int i = BlockList.Count - 1; i > -1; i--)
			{
				BlockList[i].Destroy();
			}
			BlockList.MakeTwoWay();

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			for (int i = BlockList.Count - 1; i > -1; i--)
			{
				BlockList[i].Destroy();
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			for (int i = 0; i < BlockList.Count; i++)
			{
				BlockList[i].ConvertToManuallyUpdated();
			}
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new System.ArgumentException("contentManagerName cannot be empty or null");
			}
			#if DEBUG
			if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			return null;
		}
		public static object GetFile (string memberName)
		{
			return null;
		}
		object GetMember (string memberName)
		{
			return null;
		}


	}
}
