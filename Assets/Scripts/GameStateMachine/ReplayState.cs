using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class ReplayState : GameState
    {
        public ReplayState(ApplicationStarter _application) : base(_application)
        {
        }
        
        public override void OnEnter()
        {
            application.Reset();
            
            application.UIManager.TimerUI.SetDefaultTimer();
            application.UIManager.TimerUI.StartCountDown();
            
            application.InputManager.InputRecorder.StartReplay();
        }

        public override void OnExit()
        {
            application.Reset();
            
            application.UIManager.TimerUI.SetTimer(0);
            application.UIManager.TimerUI.StopCountDown();
            
            application.InputManager.InputRecorder.StopReplay();
        }

        public override void OnUpdate()
        {
            application.InputManager.InputRecorder.UpdateReplay();
        }
    }
}
