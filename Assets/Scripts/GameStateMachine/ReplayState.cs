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

            application.UIManager.HealthBarUI_PlayerOne.SetHealthBar(1);
            application.UIManager.HealthBarUI_PlayerTwo.SetHealthBar(1);
            
            application.UIManager.TimerUI.SetDefaultTimer();
            application.UIManager.TimerUI.StartCountDown();
            
            application.CameraManager.StartUpdate();
            
            application.InputManager.StartReplay();
        }

        public override void OnExit()
        {
            application.Reset();
            
            application.UIManager.TimerUI.SetTimer(0);
            application.UIManager.TimerUI.StopCountDown();
            
            application.CameraManager.StopUpdate();
            application.CameraManager.ResetCamera();
            
            application.InputManager.StopReplay();
        }

        public override void OnUpdate()
        {
            application.InputManager.UpdateReplay();
        }
    }
}
