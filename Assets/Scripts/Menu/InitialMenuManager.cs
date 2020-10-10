﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InitialMenuManager : MonoBehaviour
{
    [Header("Menu Configurations")] 
    private const string InitialMenuName = "InitialMenu";
    private const string PlayMenuName = "PlayMenu";
    private const string QuitMenuName = "QuitMenu";
    private GameObject _initialMenu;
    private GameObject _playMenu;
    private GameObject _quitMenu;

    private MenuSoundButton _menuSoundButton;
    private MenuManager _menuManager;
    
    private void Start()
    {
        _menuSoundButton = gameObject.GetComponent<MenuSoundButton>();

        _menuManager = gameObject.GetComponent<MenuManager>();

        var parent = transform.parent;
        _initialMenu = _menuManager.GetMenuByName(parent.gameObject, InitialMenuName);
        _playMenu = _menuManager.GetMenuByName(parent.gameObject, PlayMenuName);
        _quitMenu = _menuManager.GetMenuByName(parent.gameObject, QuitMenuName);
    }

    public void QuitButton()
    {
        _menuSoundButton.PlayButtonClickSound();
        
        _menuManager.ChangeMenu(_initialMenu, _quitMenu);
    }
    
    public void PlayButton()
    {
        _menuSoundButton.PlayButtonClickSound();
        
        _menuManager.ChangeMenu(_initialMenu, _playMenu);
    }
}
