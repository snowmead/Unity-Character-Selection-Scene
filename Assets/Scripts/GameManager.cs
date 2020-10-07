﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WebSocketSharp;

public class GameManager : MonoBehaviour
{
    private const string CharacterPreviewComponents = "CharacterPreviewComponents";
    public static GameManager Instance;

    public GameObject characters;
    public GameObject[] _characters;

    private void Start()
    {
        Instance = this;

        _characters = new GameObject[characters.transform.childCount];
        for (int i = 0; i < characters.transform.childCount; i++)
        {
            for (int x = 0; x < characters.transform.GetChild(i).transform.childCount; x++)
            {
                if (characters.transform.GetChild(i).GetChild(x).gameObject.name !=
                    CharacterPreviewComponents) continue;
                _characters[i] = characters.transform.GetChild(i).GetChild(x).gameObject;
                x = characters.transform.GetChild(i).transform.childCount;
            }
        }
    }

    public void SetCurrentCharacterPreview(string characterName)
    {
        GameObject[] nonSelectedCharacterPreviews = 
            _characters.Where(character => character.GetComponent<CharacterPreview>().characterName != characterName).ToArray();

        foreach (var nonSelectedCharacterPreview in nonSelectedCharacterPreviews)
        {
            nonSelectedCharacterPreview.GetComponent<CharacterPreview>().enabled = characterName.IsNullOrEmpty();
        }
    }
} 