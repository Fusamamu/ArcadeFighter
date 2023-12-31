using UnityEngine;

namespace ArcadeFighter
{
	public class ApplicationStarter : MonoBehaviour
    {
	    public int StartTimer = 60;
	    
	    public Character LeftPlayer;
	    public Character RightPlayer;

	    public AudioManager        AudioManager;
	    public InputManager        InputManager;
	    public CameraManager       CameraManager;
	    public UIManager           UIManager;
	    public StateMachineManager StateMachineManager;

	    public StageData GameStageData;
	    
	    public static GameTime GameTime = new();
        
        private void Awake()
        {
	        StateMachineManager = new StateMachineManager();

	        AudioManager       .Initialized(this);
	        InputManager       .Initialized(this);
	        CameraManager      .Initialized(this);
	        UIManager          .Initialized(this);
	        StateMachineManager.Initialized(this);
	        
	        GameTime.ResetTime();
        }

        private void Start()
        {
	        LeftPlayer .Initialized(this);
	        RightPlayer.Initialized(this);
	        
	        LeftPlayer .GetOtherPlayer();
	        RightPlayer.GetOtherPlayer();

	        LeftPlayer .StageData = GameStageData;
	        RightPlayer.StageData = GameStageData;
	       
	        InputManager.GetControl(LeftPlayer , LeftPlayer .Type);
	        InputManager.GetControl(RightPlayer, RightPlayer.Type);
	        
	        CameraManager.GetPlayersRef();
	        UIManager    .GetPlayersRef();
	        
	        AudioManager.PlayBGM();
	        GameStageData.AnimateStageColor(this);

	        StateMachineManager.ChangeState<MainMenuState>();
        }

        private void Update()
        {
	        GameTime.Update();
	        
	        InputManager       .Update();
	        CameraManager      .Update();
	        StateMachineManager.Update();
	        
	        foreach (var _character in Character.AllCharacters)
		        _character.Update();
        }

        public void ResetState(bool _transformInclude = true, bool _animationInclude = true)
        {
	        foreach (var _character in Character.AllCharacters)
	        {
		        _character.ResetHealth();

		        if (_transformInclude)
		        {
			        _character.ResetPosition();
			        _character.ResetRotation();
		        }
		        
		        if(_animationInclude)
					_character.ResetAnimation();
	        }
        }

        private void OnDestroy()
        {
	        GameTime = null;
	        Character.AllCharacters[0] = null;
	        Character.AllCharacters[1] = null;
        }
    }
}
