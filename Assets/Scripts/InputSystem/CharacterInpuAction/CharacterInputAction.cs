using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
namespace ArcadeFighter
{
	public class CharacterInputAction : IDisposable
	{
		public bool IsPressed { get; private set; }
        
		public readonly Character    TargetCharacter;
		public readonly InputAction  TargetInputAction;
		public readonly InputManager InputManager;

		public readonly string InputActionName;

		public static List<CharacterInputAction> CharacterInputActions = new List<CharacterInputAction>();

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
        
		protected virtual void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			IsPressed = true;
			InputManager.InputRecorder.RecordInput(this);
		}
        
		protected virtual void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			IsPressed = false;
			InputManager.InputRecorder.RecordInput(this);
		}
        
		public void Dispose()
		{
			TargetInputAction.Disable();
			TargetInputAction.performed -= OnPressedInputHandler;
			TargetInputAction.canceled  -= OnReleasedInputHandler;
		}
	}
}
