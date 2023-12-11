using System;
using System.Collections;
using UnityEngine;

namespace ArcadeFighter
{
	[Serializable]
	public class CameraManager
	{
		public Camera MainCamera;

		public Vector3 ZoomFrom;
		public Vector3 ZoomTo;

		[field: SerializeField] public float ZoomIntroDuration { get; private set; } = 2f;
	    [field: SerializeField] public float ZoomSpeed { get; private set; }
	    
	    [field: SerializeField] public float minZoom { get; private set; } = 3.0f;
	    [field: SerializeField] public float maxZoom { get; private set; } = 8.0f;
	    
	    public ApplicationStarter ApplicationStarter { get; private set; }

	    private Character playerOne;
	    private Character playerTwo;
	    
	    private bool isUpdate;

	    private Vector3 originPosition;

	    public void Initialized(ApplicationStarter _applicationStarter)
	    {
		    ApplicationStarter = _applicationStarter;
		    
		    var _transform = MainCamera.transform;
		    
		    originPosition = _transform.position;
		    _transform.position = ZoomFrom;
	    }

	    public void GetPlayersRef()
	    {
		    playerOne = Character.AllCharacters[0];
		    playerTwo = Character.AllCharacters[1];
	    }

	    public void StartUpdate() => isUpdate = true;
	    public void StopUpdate () => isUpdate = false;

	    public void ResetCamera()
	    {
		    MainCamera.transform.position = originPosition;
	    }

	    public void Update()
	    {
		    if(!isUpdate)
			    return;
		    
		    ZoomBasedOnPlayersDistance();
	    }
	    
	    private void ZoomBasedOnPlayersDistance()
	    {
		    float _distance = Vector3.Distance(playerOne.TargetTransform.position, playerTwo.TargetTransform.position);
		   
		    float _zoomFactor = Mathf.InverseLerp(0f, maxZoom, _distance);
		    float _targetZoom = Mathf.Lerp(minZoom, maxZoom, _zoomFactor);

		    Vector3 _currentPosition = MainCamera.transform.position;

		    float _targetZPos = Mathf.Lerp(_currentPosition.z, -_targetZoom, Time.deltaTime * ZoomSpeed);

		    MainCamera.transform.position = new Vector3(_currentPosition.x, _currentPosition.y, _targetZPos);
	    }
	    
	    public void ZoomIn()
	    {
		    
	    }

	    public void ZoomOut()
	    {
		    
	    }

	    public Coroutine StartZoomIntro()
	    {
		    return ApplicationStarter.StartCoroutine(ZoomIntroCoroutine());
	    }

	    public IEnumerator ZoomIntroCoroutine()
	    {
		    MainCamera.transform.position = ZoomFrom;
		    
		    float _elapsedTime = 0f;
		    
		    while (_elapsedTime < ZoomIntroDuration)
		    {
			    MainCamera.transform.position = Vector3.Lerp(ZoomFrom, ZoomTo, _elapsedTime / ZoomIntroDuration);
			    _elapsedTime += Time.deltaTime;
			    yield return null;
		    }

		    MainCamera.transform.position = ZoomTo;
	    }
    }
}
