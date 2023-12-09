using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class GameplayState : GameState
    {
        public GameplayState(ApplicationStarter _application) : base(_application)
        {
        }
        
        public override void OnEnter()
        {
            application.UIManager.TimerUI.SetTimer(60);
            application.UIManager.TimerUI.StartCountDown();
            application.InputManager.PlayerInput.Enable();
        }

        public override void OnExit()
        {
            application.UIManager.TimerUI.SetTimer(0);
            application.UIManager.TimerUI.StopCountDown();
            application.InputManager.PlayerInput.Disable();
        }
    }
}
