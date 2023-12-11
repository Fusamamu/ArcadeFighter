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
		public bool HasTriggered;

		public CharacterInputAction CharacterInputAction;

		public InputRecordData(float _timestamp, CharacterInputAction _characterInputAction)
		{
			CharacterInputAction = _characterInputAction;
			
			TimeStamp       = _timestamp;
			InputType       = _characterInputAction.InputType;
			IsPressed       = _characterInputAction.IsPressed;
			InputActionName = _characterInputAction.InputActionName + $"_{_characterInputAction.TargetCharacter.name}";
		}
	}
}
