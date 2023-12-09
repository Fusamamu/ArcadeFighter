using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class ApplicationStarter : MonoBehaviour
    {
	    public Character LeftPlayer;
	    public Character RightPlayer;

	    public InputManager  InputManager;
	    public CameraManager CameraManager;
       
 #if UNITY_EDITOR
        private void OnValidate()
        {
            
        }
 #endif
        
        private void Awake()
        {
	        InputManager  = new InputManager();
	        CameraManager = new CameraManager();
        }

        private void Start()
        {
	        InputManager.Initialized();
            //Title Menu
				//->Start
				//->Quit->ApplicationQuit
            //Player Select Menu
				//Player | AI vs Player| AI
				//StartGame
            //Gameplay
				//PAUSE
					//RESUME
					//Return to menu
            //TIME Up	
				//Replay
				//Retry
				//Return to menu

	        LeftPlayer .CharacterInputControl = InputManager.GetControl(LeftPlayer , LeftPlayer .Type);
	        RightPlayer.CharacterInputControl = InputManager.GetControl(RightPlayer, RightPlayer.Type);
        }

        private void Update()
        {
	        InputManager.UpdateAllInputControls();
	        
	        foreach (var _character in Character.AllCharacters)
		        _character.Update();
        }
    }
}
