using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace ArcadeFighter
{
	[Serializable]
	public class CameraManager
	{
		public enum CameraTarget
		{
			MAIN, P0, P1
		}
		
		public CinemachineVirtualCamera MainCamera;
		public CinemachineVirtualCamera LookAtP0Camera;
		public CinemachineVirtualCamera LookAtP1Camera;

		private int selectedCameraIndex;
		private List<CinemachineVirtualCamera> allCamara = new List<CinemachineVirtualCamera>();

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

		    allCamara.Add(MainCamera);
		    allCamara.Add(LookAtP0Camera);
		    allCamara.Add(LookAtP1Camera);
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

	    public void SwitchCamera()
	    {
		    selectedCameraIndex++;
		    if (selectedCameraIndex >= allCamara.Count)
			    selectedCameraIndex = 0;
		    
		    SetCameraPriority(0);
		    allCamara[selectedCameraIndex].Priority = 1;
	    }

	    public void SwitchCamera(CameraTarget _target)
	    {
		    switch (_target)
		    {
			    case CameraTarget.MAIN:
				    SetCameraPriority(0);
				    MainCamera.Priority = 1;
				    break;
			    case CameraTarget.P0:
				    SetCameraPriority(0);
				    LookAtP0Camera.Priority = 1;
				    break;
			    case CameraTarget.P1:
				    SetCameraPriority(0);
				    LookAtP1Camera.Priority = 1;
				    break;
		    }
	    }

	    private void SetCameraPriority(int _value)
	    {
		    MainCamera.Priority     = _value;
		    LookAtP0Camera.Priority = _value;
		    LookAtP1Camera.Priority = _value;
	    }
    }
}
