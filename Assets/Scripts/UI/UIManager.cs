using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class UIManager : IDisposable
    {
        public MainMenuUI   MainMenuUI;
        public TransitionUI TransitionUI;
        public TimerUI      TimerUI;
        public HealthBarUI  HealthBarUI_PlayerOne;
        public HealthBarUI  HealthBarUI_PlayerTwo;
        public GameOverUI   GameOverUI;
        
        private Dictionary<Type, GameUI> UITable = new ();
        
        public ApplicationStarter ApplicationStarter { get; private set; }
        
        public UIManager()
        {
        }

        public void Initialized(ApplicationStarter _applicationStarter)
        {
            ApplicationStarter = _applicationStarter;
            
            MainMenuUI  .Initialized(this);
            TransitionUI.Initialized(this);
            TimerUI     .Initialized(this);
            HealthBarUI_PlayerOne.Initialized(this);
            HealthBarUI_PlayerTwo.Initialized(this);
            GameOverUI .Initialized(this);
            
            TimerUI.OnTimeUpEvent.AddListener(() => ApplicationStarter.StateMachineManager.ChangeState<GameOverState>());
            
            MainMenuUI.StartGameButton.onClick.AddListener(() => ApplicationStarter.StateMachineManager.ChangeState<GameplayState>());
            MainMenuUI.QuitGameButton .onClick.AddListener(Application.Quit);
            
            GameOverUI.PlayAgainButton       .onClick.AddListener(() => ApplicationStarter.StateMachineManager.ChangeState<GameplayState>());
            GameOverUI.ReplayButton          .onClick.AddListener(() => ApplicationStarter.StateMachineManager.ChangeState<ReplayState>());
            GameOverUI.ReturnToMainMenuButton.onClick.AddListener(() => ApplicationStarter.StateMachineManager.ChangeState<MainMenuState>());
        }
        
        public void GetPlayersRef()
        {
            Character.PlayerOne.OnGetHitEvent.AddListener(_value => HealthBarUI_PlayerOne.SetHealthBar(_value));
            Character.PlayerTwo.OnGetHitEvent.AddListener(_value => HealthBarUI_PlayerTwo.SetHealthBar(_value));
        }
        
        public void Add(GameUI _ui)
        {
            if (!UITable.ContainsKey(_ui.GetType()))
                UITable.Add(_ui.GetType(), _ui);
            else
                UITable[_ui.GetType()] = _ui;
        }

        public void Dispose()
        {
            foreach (var _ui in UITable.Values)
                _ui.Dispose();
        }
    }
}
