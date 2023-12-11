using System;
using System.Collections;
using UnityEngine;

namespace ArcadeFighter
{
	[Serializable]
	public class StageData
	{
		public Transform LeftWall;
		public Transform RightWall;

		public Color GridColorFrom;
		public Color GridColorTo;

		public Material StageMaterial;

		private float lerpDuration = 2.0f;
		
		private static readonly int tintColor = Shader.PropertyToID("_TintColor");

		public void AnimateStageColor(MonoBehaviour _monoBehaviour)
		{
			_monoBehaviour.StartCoroutine(LerpColorCoroutine());
		}
		
		protected IEnumerator LerpColorCoroutine()
		{
			Color _from = GridColorFrom;
			Color _to   = GridColorTo;

			bool _isForward = true;
			
			while (true)
			{
				float _elapsedTime = 0f;
				while (_elapsedTime < lerpDuration)
				{
					var _color = Color.Lerp(_from, _to, _elapsedTime / lerpDuration);
					StageMaterial.SetColor(tintColor, _color);
					_elapsedTime += Time.deltaTime;
					yield return null;
				}

				StageMaterial.color = _to;

				_isForward = !_isForward;
				_from = _isForward ? GridColorFrom : GridColorTo;
				_to =   _isForward ? GridColorTo   : GridColorFrom;
				
				yield return new WaitForSeconds(0.1f); 
			}
		}
	}
}
