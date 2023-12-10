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
            ApplicationStarter
                .GameTime
                .ResetTime()
                .StartUpdate();
            
            application.Reset();
            
            application.UIManager.TimerUI.SetDefaultTimer();
            application.UIManager.TimerUI.StartCountDown();
            
            application.InputManager.StartUpdateInputControl();
            application.InputManager.PlayerInput.Enable();
            
            application.InputManager.InputRecorder.ClearInputRecord();
        }

        public override void OnExit()
        {
            ApplicationStarter
                .GameTime
                .ResetTime()
                .StopUpdate();
            
            application.Reset();
            
            application.UIManager.TimerUI.SetTimer(0);
            application.UIManager.TimerUI.StopCountDown();
            
            application.InputManager.StopUpdateInputControl();
            application.InputManager.PlayerInput.Disable();
        }
    }
}
