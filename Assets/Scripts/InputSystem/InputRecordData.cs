using System;
using UnityEngine.InputSystem;
namespace ArcadeFighter
{
	[Serializable]
	public class InputRecordData
	{
		public string InputActionName;
		
		public InputType InputType;
		
		public float TimeStamp;
		public bool IsPressed;
		
		public bool IsTriggerred;
		public Character Character;
		
		public readonly InputAction InputAction;

		public bool HasTriggered;

		public CharacterInputAction CharacterInputAction;

		public InputRecordData(float _timestamp, CharacterInputAction _characterInputAction)
		{
			CharacterInputAction = _characterInputAction;
			
			InputType       = _characterInputAction.InputType;
			TimeStamp       = _timestamp;
			Character       = _characterInputAction.TargetCharacter;
			InputAction     = _characterInputAction.TargetInputAction;
			InputActionName = _characterInputAction.InputActionName;
			IsPressed       = _characterInputAction.IsPressed;
			IsTriggerred    = _characterInputAction.IsTriggerred;
		}
	}
}
