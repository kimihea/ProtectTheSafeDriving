using UnityEngine;

class SaveScore : MonoBehaviour
{
    private InputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        if (inputManager != null)
        {
            inputManager.OnMove += Save;
        }
    }
    void Save(Vector2 direction)
    {
        GameManager.Instance.curScore = this.transform.position.z;
        GameManager.Instance.curHighScore = Mathf.Max(GameManager.Instance.curHighScore, GameManager.Instance.curScore);
        GameManager.Instance.highScore = Mathf.Max(GameManager.Instance.highScore, GameManager.Instance.curHighScore);
        PlayerPrefs.SetFloat("highScore", GameManager.Instance.curHighScore);
    }

}