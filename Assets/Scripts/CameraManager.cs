using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
	public class CameraManager
	{
		public static Camera MainCamera;
		
	    [field: SerializeField] public float ZoomSpeed { get; private set; }

	    public CameraManager()
	    {
		    MainCamera = Camera.main;
	    }

	    public void ZoomIn()
	    {
		    
	    }

	    public void ZoomOut()
	    {
		    
	    }
    }
}
