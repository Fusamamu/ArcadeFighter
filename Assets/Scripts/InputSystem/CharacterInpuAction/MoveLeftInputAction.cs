using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class MoveLeftInputAction : CharacterInputAction
	{
		private float moveLeftValue;
        
		public MoveLeftInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
		}
        
		public override void Update()
		{
			moveLeftValue = TargetInputAction.ReadValue<float>();
			TargetCharacter.MoveLeft (moveLeftValue);
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnPressedInputHandler(_context);
			TargetCharacter.MoveLeft(_context);
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnReleasedInputHandler(_context);
			TargetCharacter.MoveLeft(_context);
		}
	}
}
