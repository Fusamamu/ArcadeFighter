using System;
using TMPro;
using UnityEngine.UI;

namespace ArcadeFighter
{
    [Serializable]
    public class GameOverUI : GameUI
    {
        public Image PanelImage;
        
        public TextMeshProUGUI GameOverText;
        
        public Button PlayAgainButton;
        public Button ReplayButton;
        public Button ReturnToMainMenuButton;
        
        public override void Initialized(UIManager _uiManager)
        {
            base.Initialized(_uiManager);
        }
        
        public override void Open()
        {
            base.Open();
            UIParent.gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            UIParent.gameObject.SetActive(false);
        }
    }
}
