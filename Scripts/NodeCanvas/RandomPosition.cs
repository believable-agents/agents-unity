using UnityEngine;
using System.Collections;
using NodeCanvas;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace ViAgents.NodeCanvas.Actions 
{
	[Name("Random Position In Bounds")]
    [Category("★ Agents")]
    public class RandomPosition : ActionTask<Transform>
	{
		public BBParameter<Vector3> position;

		public float radius = 60f;
	    public BBParameter<ConvexBounds> convexBounds;

        //public ConvexBounds convexBounds;
	    private ConvexBounds currentBounds;

		protected override void OnExecute ()
		{
            currentBounds = convexBounds.value;
		    if (currentBounds == null)
		    {
		        Debug.LogError("Bounds not initialised!");
		    }

            try
		    {
		        position.value = this.currentBounds.RandomPosition();
		        EndAction(true);
		    }
		    catch (System.Exception ex)
		    {
                Debug.LogError("Error creating random position: " + ex.Message);
                EndAction(false);
            }
		
		}
	}
}

