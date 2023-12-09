using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class GameOverState : GameState
    {
        public GameOverState(ApplicationStarter _application) : base(_application)
        {
        }
        
        public override void OnEnter()
        {
            application.UIManager.GameOverUI.Open();
        }

        public override void OnExit()
        {
            application.UIManager.GameOverUI.Close();
        }
    }
}
