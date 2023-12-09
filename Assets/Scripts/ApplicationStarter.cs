using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
	// UIManager   .Initialized();
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
					
	//Game Over	
	//Replay
	//Retry
	//Return to menu
	
    public class ApplicationStarter : MonoBehaviour
    {
	    public int StartTimer = 60;
	    
	    public Character LeftPlayer;
	    public Character RightPlayer;

	    public InputManager        InputManager;
	    public CameraManager       CameraManager;
	    public UIManager           UIManager;
	    public StateMachineManager StateMachineManager;
       
 #if UNITY_EDITOR
        private void OnValidate()
        {
            
        }
 #endif
        
        private void Awake()
        {
	        StateMachineManager = new StateMachineManager();
	        
	        InputManager       .Initialized(this);
	        UIManager          .Initialized(this);
	        StateMachineManager.Initialized(this);
        }

        private void Start()
        {
	        LeftPlayer .CharacterInputControl = InputManager.GetControl(LeftPlayer , LeftPlayer .Type);
	        RightPlayer.CharacterInputControl = InputManager.GetControl(RightPlayer, RightPlayer.Type);

	        UIManager.TimerUI.OnTimeUp += () =>
	        {
				UIManager.GameOverUI.Open();
	        };
        }

        private void Update()
        {
	        InputManager.UpdateAllInputControls();
	        
	        foreach (var _character in Character.AllCharacters)
		        _character.Update();
        }
    }
}
