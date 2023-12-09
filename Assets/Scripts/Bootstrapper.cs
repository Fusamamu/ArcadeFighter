// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
//
// namespace ArcadeFighter
// {
// 	public class Bootstrapper : MonoBehaviour
// 	{
// 		public Bootstrapper Instance { get; private set; }
// 		
// 		private static string bootstrapperSceneName = "Bootstrapper";
//
// 		private void Awake()
// 		{
// 			if (Instance != null)
// 			{
// 				Instance = null;
// 				Destroy(gameObject);
// 				return;
// 			}
//
// 			DontDestroyOnLoad(gameObject);
// 		}
//
// 		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
// 		private static void PerformBootstrapper()
// 		{
// 			if (!SceneManager.GetSceneByName(bootstrapperSceneName).isLoaded)
// 				SceneManager.LoadScene(bootstrapperSceneName, LoadSceneMode.Additive);
// 		}
// 	}
// }
