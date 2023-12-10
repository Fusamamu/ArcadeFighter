using System;
using UnityEngine.InputSystem;
namespace ArcadeFighter
{
	[Serializable]
	public class InputRecordData
	{
		public float TimeStamp;
		public bool IsPressed;
		public bool IsTriggerred;
		public string InputActionName;
		
		public Character Character;
		public readonly InputAction InputAction;

		public CharacterInputAction CharacterInputAction;

		public InputRecordData(float _timestamp, CharacterInputAction _characterInputAction)
		{
			CharacterInputAction = _characterInputAction;
			
			TimeStamp       = _timestamp;
			Character       = _characterInputAction.TargetCharacter;
			InputAction     = _characterInputAction.TargetInputAction;
			InputActionName = _characterInputAction.InputActionName;
			IsPressed       = _characterInputAction.IsPressed;
			IsTriggerred    = _characterInputAction.IsTriggerred;
		}

		public void RunRecord()
		{
			CharacterInputAction.RunPressedActionCommand();
		}
	}
}
