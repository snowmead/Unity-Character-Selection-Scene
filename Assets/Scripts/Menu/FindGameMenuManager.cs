﻿using UnityEngine;

namespace Menu
{
    public class FindGameMenuManager : MonoBehaviour
    {
        [Header("Menu Configurations")] 
        private const string PlayMenuName = "PlayMenu";
        private const string FindGameMenuName = "FindGameMenu";
        private GameObject _playMenu;
        private GameObject _findGameMenu;

        private MenuSoundButton _menuSoundButton;
        
        private MenuManager _menuManager;
        
        private void Start()
        {
            _menuSoundButton = gameObject.GetComponent<MenuSoundButton>();
        
            _menuManager = gameObject.GetComponent<MenuManager>();
            
            var parent = transform.parent;
            _playMenu = _menuManager.GetMenuByName(parent.gameObject, PlayMenuName);
            _findGameMenu = _menuManager.GetMenuByName(parent.gameObject, FindGameMenuName);
        }

        public void BackButton()
        {
            _menuSoundButton.PlayButtonClickSound();
        
            _menuManager.ChangeMenu(_findGameMenu, _playMenu);
        }
    }
}
