using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIPages
{
    Lose,
    Paint,
    Start,
    Run
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject losePage;
    [SerializeField] private GameObject startPage;
    [SerializeField] private GameObject paintPage;
    [SerializeField] private GameObject rankPage;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError($"Another instance of {GetType()} already exist! Destroying self...");
            Destroy(this);
        }
    }

    public void SetUIPage(UIPages uiPages)
    {
        switch (uiPages)
        {
            case UIPages.Lose:
                OpenPage(losePage);
                break;
            case UIPages.Paint:
                OpenPage(paintPage);
                break;
            case UIPages.Start:
                OpenPage(startPage);
                break;
            case UIPages.Run:
                CloseAllPages();
                rankPage.SetActive(true);
                break;
        }
    }

    private void OpenPage(GameObject page)
    {
        CloseAllPages();
        page.SetActive(true);
    }

    private void CloseAllPages()
    {
        losePage.SetActive(false);
        startPage.SetActive(false);
        paintPage.SetActive(false);
        rankPage.SetActive(false);
    }

}