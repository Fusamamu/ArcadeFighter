using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class UIManager : IDisposable
    {
        public MainMenuUI  MainMenuUI;
        public TimerUI     TimerUI;
        public HealthBarUI HealthBarUI;
        public GameOverUI  GameOverUI;
        
        private Dictionary<Type, GameUI> UITable = new Dictionary<Type, GameUI>();
        
        public ApplicationStarter ApplicationStarter { get; private set; }
        
        public UIManager()
        {
        }

        public void Initialized(ApplicationStarter _applicationStarter)
        {
            ApplicationStarter = _applicationStarter;
            
            MainMenuUI.Initialized(this);
            TimerUI   .Initialized(this);
            GameOverUI.Initialized(this);
            
            MainMenuUI.StartGameButton.onClick.AddListener(() =>
            {
                ApplicationStarter.StateMachineManager.ChangeState<GameplayState>();
            });

            MainMenuUI.QuitGameButton.onClick.AddListener(Application.Quit);
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
