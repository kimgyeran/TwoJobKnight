using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private GameObject statUI;
    [SerializeField] private GameObject dungeonUI;
    [SerializeField] private GameObject monsterUI;
    [SerializeField] private GameObject menuPanel;


    [Header("Menu Buttons")]
    [SerializeField] private Button shopButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button statButton;
    [SerializeField] private Button dungeonButton;
    [SerializeField] private Button monsterButton;

    [Header("Return Buttons")]
    [SerializeField] private Button returnButton;
    private GameObject currentUI;

    private void Start()
    {
        InitializeUI();
        SetupButtons();
    }

    private void InitializeUI()
    {
        menuPanel.SetActive(true);
        shopUI.SetActive(false);
        statUI.SetActive(false);
        returnButton.gameObject.SetActive(false);
    }

    private void SetupButtons()
    {

        shopButton.onClick.AddListener(() => OpenUI(shopUI));
        upgradeButton.onClick.AddListener(() => OpenUI(upgradeUI));
        statButton.onClick.AddListener(() => OpenUI(statUI));
        dungeonButton.onClick.AddListener(() => OpenUI(dungeonUI));
        monsterButton.onClick.AddListener(() => OpenUI(monsterUI));
        returnButton.onClick.AddListener(ReturnToMenu);
    }

    private void OpenUI(GameObject ui)
    {
        menuPanel.SetActive(false);
        ui.SetActive(true);
        returnButton.gameObject.SetActive(true);
        currentUI = ui;
    }

    private void ReturnToMenu()
    {
        currentUI.SetActive(false);
        returnButton.gameObject.SetActive(false);
        menuPanel.SetActive(true);
    }
}
