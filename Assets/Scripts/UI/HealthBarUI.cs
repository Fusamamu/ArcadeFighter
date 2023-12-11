using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class HealthBarUI : GameUI
    {
        public RectTransform BarRectTransform;
        
        public override void Open()
        { 
            base.Open();
            UIParent.gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            UIParent.gameObject.SetActive(false);
        }

        public void SetHealthBar(float _percent)
        {
            if (_percent < 0)
                _percent = 0;
            
            BarRectTransform.localScale = new Vector3(_percent, 1, 1);
        }

        public Coroutine StartAnimateHealthBarToMax()
        {
            return application.StartCoroutine(AnimateHealthBarToMaxCoroutine());
        }

        public IEnumerator AnimateHealthBarToMaxCoroutine(Action _onComplete = null)
        {
            BarRectTransform.localScale = new Vector3(0, 1, 1);

            float _v = 0;

            while (_v < 1f)
            {
                _v += Time.deltaTime;
                BarRectTransform.localScale = new Vector3(_v, 1, 1);
                yield return null;
            }
            
            BarRectTransform.localScale = new Vector3(1, 1, 1);
            
            _onComplete?.Invoke();
        }
    }
}
