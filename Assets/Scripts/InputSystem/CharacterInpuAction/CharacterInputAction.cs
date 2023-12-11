using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public enum InputType
	{
		PRESSHOLD, 
		CLICK
	}

	public class InputState
	{
		public bool PlayerHoldPress;
		public bool CanPress;
		public CharacterInputAction CharacterInputAction;
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

		protected static Dictionary<PlayerType, InputState> InputStateTable = new ()
		{
			{ PlayerType.PLAYER_ONE, new InputState() },
			{ PlayerType.PLAYER_TWO, new InputState() },
		};

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
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
			{
				if (!_state.PlayerHoldPress)
				{
					_state.PlayerHoldPress     = true;
					_state.CharacterInputAction = this;
				}
			}
			
			IsPressed = true;
			InputManager.RecordInput(TargetCharacter.Type, this);
		}
        
		protected virtual void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
			{
				if (_state.PlayerHoldPress && _state.CharacterInputAction == this)
					_state.PlayerHoldPress = false;
			}

			if (IsPressed)
			{
				IsPressed = false;
				
				if(InputType != InputType.CLICK)
					InputManager.RecordInput(TargetCharacter.Type, this);
			}
		}

		protected virtual bool CanPress()
		{
			return !TargetCharacter.IsSprintingForward;
		}
        
		public void Dispose()
		{
			TargetInputAction.Disable();
			TargetInputAction.performed -= OnPressedInputHandler;
			TargetInputAction.canceled  -= OnReleasedInputHandler;
		}
	}
}
