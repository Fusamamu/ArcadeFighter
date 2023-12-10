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
            application.Reset();
            application.InputManager.InputRecorder.ClearInputRecord();

            application.StartCoroutine(OnEnterCoroutine());
        }

        private IEnumerator OnEnterCoroutine()
        {
            var _healthAnimationP0  = application.UIManager.HealthBarUI_PlayerOne.StartAnimateHealthBarToMax();
            var _healthAnimationP1  = application.UIManager.HealthBarUI_PlayerTwo.StartAnimateHealthBarToMax();
            var _timerAnimation     = application.UIManager.TimerUI.StartSetDefaultTimer();
            var _introTextAnimation = application.UIManager.TransitionUI.StartAnimateIntroText();
            var _introZoomAnimation = application.CameraManager.StartZoomIntro();
            
            yield return _healthAnimationP0;
            yield return _healthAnimationP1;
            yield return _timerAnimation;
            yield return _introTextAnimation;
            yield return _introZoomAnimation;
            
            application.UIManager.TimerUI.StartCountDown();
            
            application.InputManager.StartUpdateInputControl();
            application.InputManager.PlayerInput.Enable();
            
            ApplicationStarter
                .GameTime
                .ResetTime()
                .StartUpdate();
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
