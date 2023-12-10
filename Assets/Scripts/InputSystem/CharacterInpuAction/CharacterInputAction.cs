using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class CharacterInputAction : IDisposable
	{
		public bool IsPressed    { get; protected set; }
		public bool IsTriggerred { get; protected set; }
        
		public readonly Character    TargetCharacter;
		public readonly InputAction  TargetInputAction;
		public readonly InputManager InputManager;

		public readonly string InputActionName;

		public CharacterInputAction(Character _character, InputAction _inputAction, InputManager _inputManager)
		{
			TargetCharacter   = _character;
			TargetInputAction = _inputAction;
			InputManager      = _inputManager;
            
			TargetInputAction.Disable();
			TargetInputAction.performed += OnPressedInputHandler;
			TargetInputAction.canceled  += OnReleasedInputHandler;

			InputActionName = _inputAction.name;
		}

		public virtual void Update()
		{
            
		}

		public virtual void RunPressedActionCommand()
		{
			
		}

		public virtual void RunReleasedActionCommand()
		{
			
		}
        
		protected virtual void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			IsPressed = true;
			InputManager.InputRecorder.RecordInput(this);
			Debug.Log(IsPressed);
		}
        
		protected virtual void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			IsPressed = false;
			InputManager.InputRecorder.RecordInput(this);
			Debug.Log(IsPressed);
		}
        
		public void Dispose()
		{
			TargetInputAction.Disable();
			TargetInputAction.performed -= OnPressedInputHandler;
			TargetInputAction.canceled  -= OnReleasedInputHandler;
		}
	}
}
