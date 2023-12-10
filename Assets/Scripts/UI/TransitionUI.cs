using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class TransitionUI : GameUI
    {
        public TextMeshProUGUI CenterText;

        public float AnimationInterval;
        public float ScaleInterval;

        public List<string> IntroText;

        public Coroutine StartAnimateIntroText()
        {
            return application.StartCoroutine(AnimateIntroTextCoroutine());
        }

        public IEnumerator AnimateIntroTextCoroutine()
        {
            CenterText.SetText(string.Empty);
            
            Open();
            int _index = 0;

            while (_index < IntroText.Count)
            {
                var _text = IntroText[_index];
                CenterText.SetText(_text);
                yield return ScaleTextCoroutine();
                yield return new WaitForSeconds(AnimationInterval);
                _index++;
            }
            Close();
        }

        private IEnumerator ScaleTextCoroutine()
        {
            float _scale = 0f;
            
            while (_scale < 1f)
            {
                CenterText.transform.localScale = new Vector3(_scale, _scale, 1);
                _scale += Time.deltaTime;
                yield return new WaitForSeconds(ScaleInterval);
            }
            
            CenterText.transform.localScale = new Vector3(1, 1, 1);
        }
        
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
    }
}
