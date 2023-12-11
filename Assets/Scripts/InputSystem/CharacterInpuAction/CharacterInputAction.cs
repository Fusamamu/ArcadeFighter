using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public enum InputType
	{
		PRESSHOLD, 
		CLICK
	}
	
	public class CharacterInputAction : IDisposable
	{
		public InputType InputType;
		
		public bool IsPressed    { get; protected set; }
		public bool IsTriggerred { get; protected set; }
        
		public readonly Character    TargetCharacter;
		public readonly InputAction  TargetInputAction;
		public readonly InputManager InputManager;

		public readonly string InputActionName;

		public static CharacterInputAction CurrentInputAction;
		public static bool PlayerHeldPress;

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
			if (!PlayerHeldPress)
			{
				PlayerHeldPress    = true;
				CurrentInputAction = this;
			}
			
			IsPressed = true;
			InputManager.InputRecorder.RecordInput(this);
		}
        
		protected virtual void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			if (PlayerHeldPress && CurrentInputAction == this)
				PlayerHeldPress = false;

			if (IsPressed)
			{
				IsPressed = false;
				
				if(InputType != InputType.CLICK)
					InputManager.InputRecorder.RecordInput(this);
			}
		}

		protected virtual bool CanPress()
		{
			return !TargetCharacter.IsActionProcess;
		}
        
		public void Dispose()
		{
			TargetInputAction.Disable();
			TargetInputAction.performed -= OnPressedInputHandler;
			TargetInputAction.canceled  -= OnReleasedInputHandler;
		}
	}
}
