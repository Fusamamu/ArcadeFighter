using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ArcadeFighter
{
    [Serializable]
    public class TimerUI : GameUI
    {
        public float AnimationInterval = 0.02f;
        public TextMeshProUGUI CountDownText;

        private int timer;
        private Coroutine countDownCoroutine;

        public UnityEvent OnTimeUpEvent;

        public override void Initialized(UIManager _uiManager)
        {
            base.Initialized(_uiManager);
        }

        public Coroutine StartSetDefaultTimer()
        {
            return application.StartCoroutine(SetDefaultTimerCoroutine());
        }

        public IEnumerator SetDefaultTimerCoroutine()
        {
            SetTimer(0);

            int _timer = 0;
            
            while (_timer < application.StartTimer)
            {
                _timer++;
                SetTimer(_timer);
                yield return new WaitForSeconds(AnimationInterval);
            }
            
            SetDefaultTimer();
        }

        public void SetDefaultTimer()
        {
            SetTimer(application.StartTimer);
        }

        public void SetTimer(int _value)
        {
            timer = _value;
            CountDownText.SetText(timer.ToString("00"));
        }
        
        public void StartCountDown()
        {
            StopCountDown();
            countDownCoroutine = application.StartCoroutine(CountDownCoroutine());
        }
        
        public void StopCountDown()
        {
            if (countDownCoroutine != null)
            {
                application.StopCoroutine(countDownCoroutine);
                countDownCoroutine = null;
            }
        }
        
        private IEnumerator CountDownCoroutine()
        {
            while (timer > 0)
            {
                timer--;
                yield return new WaitForSeconds(1);
                CountDownText.SetText(timer.ToString("00"));
            }

            OnTimeUpEvent?.Invoke();
        }
        
        public override void Dispose()
        {
            OnTimeUpEvent.RemoveAllListeners();
        }
    }
}
