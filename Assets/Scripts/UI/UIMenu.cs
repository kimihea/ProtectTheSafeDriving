using TMPro;
using UnityEngine;
using UnityEngine.UI;

class UIMenu : MonoBehaviour
{
    public Button startBtn;
    public Button carBtn;
    public TextMeshProUGUI HighScoreTxt;
    private void Awake()
    {
        startBtn.onClick.AddListener(GameManager.Instance.OnStartGame);
        carBtn.onClick.AddListener (GameManager.Instance.OnSelectCar);
        HighScoreTxt.text = $"<sprite=3>무사고 {GameManager.Instance.highScore}일차<sprite=3>";
    }
}