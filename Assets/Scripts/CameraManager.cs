using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
	[Serializable]
	public class CameraManager
	{
		public Camera MainCamera;

		public Vector3 ZoomFrom;
		public Vector3 ZoomTo;

		public float Duration = 2f;
	    [field: SerializeField] public float ZoomSpeed { get; private set; }
	    
	    public ApplicationStarter ApplicationStarter { get; private set; }

	    public void Initialized(ApplicationStarter _applicationStarter)
	    {
		    ApplicationStarter = _applicationStarter;
	    }

	    public Coroutine StartZoomIntro()
	    {
		    return ApplicationStarter.StartCoroutine(ZoomIntroCoroutine());
	    }

	    public IEnumerator ZoomIntroCoroutine()
	    {
		    MainCamera.transform.position = ZoomFrom;
		    
		    float _elapsedTime = 0f;
		    
		    while (_elapsedTime < Duration)
		    {
			    MainCamera.transform.position = Vector3.Lerp(ZoomFrom, ZoomTo, _elapsedTime / Duration);
			    _elapsedTime += Time.deltaTime;
			    yield return null;
		    }

		    MainCamera.transform.position = ZoomTo;
	    }
	    
	    public void ZoomIn()
	    {
		    
	    }

	    public void ZoomOut()
	    {
		    
	    }

	    public IEnumerator ZoomOutCoroutine()
	    {
		    yield return null;
	    }
    }
}
