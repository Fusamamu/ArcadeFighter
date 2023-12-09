using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class TimerUI : GameUI
    {
        public TextMeshProUGUI CountDownText;

        private int timer;
        private Coroutine countDownCoroutine;
        
        public event Action OnTimeUp = delegate { };

        public override void Initialized(UIManager _uiManager)
        {
            base.Initialized(_uiManager);

            //OnTimeUp += application.StopPlay;
        }

        public void SetTimer(int _value)
        {
            timer = _value;
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

            OnTimeUp?.Invoke();
        }
        
        public override void Dispose()
        {
            //OnTimeUp -= application.StopPlay;
        }
    }
}
