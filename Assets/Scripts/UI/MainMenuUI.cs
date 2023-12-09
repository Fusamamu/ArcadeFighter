using System;
using TMPro;
using UnityEngine.UI;

namespace ArcadeFighter
{
    [Serializable]
    public class MainMenuUI : GameUI
    {
        public Image PanelImage;
        
        public TextMeshProUGUI GameTitleText;
        
        public Button StartGameButton;
        public Button QuitGameButton;
        
        public override void Initialized(UIManager _uiManager)
        {
            base.Initialized(_uiManager);
            
            StartGameButton.onClick.AddListener(Close);
            QuitGameButton.onClick.AddListener(() =>
            {
            });
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

        public override void Dispose()
        {
            StartGameButton.onClick.RemoveAllListeners();
            QuitGameButton .onClick.RemoveAllListeners();
        }
    }
}
