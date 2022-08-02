using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankUI;
    [SerializeField] private TextMeshProUGUI ordinalUI;

    private GameObject[] _allCharacters;
    private int _rank;


    private Color _goldColor = new Color(255, 215, 0);
    private Color _silverColor = new Color(192, 192, 192);
    private Color _copperColor = new Color(184, 115, 51);

    private void Awake()
    {
        _allCharacters = GameObject.FindGameObjectsWithTag("Character");
    }

    private void Update()
    {
        UpdateRank();
    }

    private void UpdateRank()
    {
        if (GameStateManager.Instance.CurrentState == GameStates.Run)
        {
            _rank = 1;
            foreach (var character in _allCharacters)
            {
                if (transform.position.x < character.transform.position.x)
                {
                    _rank++;
                }
            }

            RefreshRankUI(_rank);
        }
    }

    private void RefreshRankUI(int rank)
    {
        RefreshUIText(rank);
        RefreshUIColor(rank);
    }

    private void RefreshUIColor(int rank)
    {
        switch (rank)
        {
            case 1:
                ordinalUI.color = _goldColor;
                rankUI.color = _goldColor;
                break;
            case 2:
                ordinalUI.color = _silverColor;
                rankUI.color = _silverColor;
                break;
            case 3:
                ordinalUI.color = _copperColor;
                rankUI.color = _copperColor;
                break;
            default:
                ordinalUI.color = Color.white;
                rankUI.color = Color.white;
                break;
        }
    }

    private void RefreshUIText(int rank)
    {
        rankUI.text = rank.ToString();
        ordinalUI.text = rank switch
        {
            2 => "ND",
            3 => "RD",
            _ => "TH"
        };
    }
}