using UnityEngine;

namespace ArcadeFighter
{
	public class GameTime
	{
		public float ElapsedTime;

		private bool isUpdate;

		public void StartUpdate()
		{
			isUpdate = true;
		}

		public void StopUpdate()
		{
			isUpdate = false;
		}

		public void Update()
		{
			if(!isUpdate)
				return;
			
			ElapsedTime += Time.deltaTime;
		}
		
		public GameTime ResetTime()
		{
			ElapsedTime = 0;
			return this;
		}
	}
}
