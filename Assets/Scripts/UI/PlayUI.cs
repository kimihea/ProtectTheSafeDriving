using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI highScore;
    public Button Retry;
    public Button Menu;
    public InputManager InputManager;
    public GameObject endPanel;
    // Update is called once per frame
    private void Start()
    {
        InputManager = FindObjectOfType<InputManager>();
        InputManager.OnMenu += ToggleMenu;
        Retry.onClick.AddListener(GameManager.Instance.OnStartGame);
        Menu.onClick.AddListener(GameManager.Instance.OnSelectMenu);
        GameManager.Instance.curHighScore = 0f;
    }

    private void ToggleMenu()
    {
        endPanel.SetActive(!endPanel.activeSelf);
    }

    void Update()
    {
        
        money.text = GameManager.Instance.money.ToString();
        score.text = $"무사고 {GameManager.Instance.curHighScore}일차";
        highScore.text = $"최고 점수 :{GameManager.Instance.highScore}";
        score2.text =$"내 점수: {GameManager.Instance.curHighScore}";
    }

}
