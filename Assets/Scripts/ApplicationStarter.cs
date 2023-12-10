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

	    public static GameTime GameTime = new();
	    
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
	        
	        GameTime.ResetTime();
        }

        private void Start()
        {
	        LeftPlayer .Initialized();
	        RightPlayer.Initialized();
	        
	        LeftPlayer .CharacterInputControl = InputManager.GetControl(LeftPlayer , LeftPlayer .Type);
	        RightPlayer.CharacterInputControl = InputManager.GetControl(RightPlayer, RightPlayer.Type);
        }

        private void Update()
        {
	        GameTime.Update();
	        
	        InputManager       .Update();
	        StateMachineManager.Update();
	        
	        foreach (var _character in Character.AllCharacters)
		        _character.Update();
        }

        public void Reset()
        {
	        foreach (var _character in Character.AllCharacters)
		        _character.ResetPosition();
        }

        private void OnDestroy()
        {
	        GameTime = null;
	        Character.AllCharacters.Clear();
        }
    }
}
