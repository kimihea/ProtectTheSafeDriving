using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance ;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                //_instance = FindObjectOfType<GameManager>();
                //if (_instance == null)
                //{
                    GameObject gameManager = new GameObject("GameManager");
                    _instance = gameManager.AddComponent<GameManager>();
                //}
            }
            return _instance;
        }
    }
    TextMeshProUGUI HighScoreTxt;
    public float highScore;
    public float curScore;
    public float curHighScore;
    public float money;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    
    public void OnStartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnSelectCar()
    {
        SceneManager.LoadScene("Car");
    }
    public void OnSelectMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

}
