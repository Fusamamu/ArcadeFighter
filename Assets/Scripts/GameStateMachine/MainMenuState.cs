using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class MainMenuState : GameState
    {
        public MainMenuState(ApplicationStarter _application) : base(_application)
        {
        }
        
        public override void OnEnter()
        {
            application.UIManager.MainMenuUI.Open();
        }

        public override void OnExit()
        {
            application.UIManager.MainMenuUI.Close();
        }
    }
}
