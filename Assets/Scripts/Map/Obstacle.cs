using Unity.VisualScripting;
using UnityEngine;

class Obstacle: MonoBehaviour
{
    InputManager inputManager;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
            inputManager.OnMenu?.Invoke();
        inputManager.state = GameState.GameOver;
         AudioManager.Instance.PlayEffect("Effect/DM-CGS-48");
    }
}