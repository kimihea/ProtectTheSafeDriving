using System;
using UnityEngine;

public enum GameState
{
    Running,
    Paused,
    GameOver
}
public class InputManager : MonoBehaviour
{
    public float moveDistance = 1.0f; // 한 번의 이동 거리
    private Vector2 moveDirection;
    public Action<Vector2> OnMove;
    public Action OnMenu;
    public GameState state;
    private void Awake()
    {
        OnMove += MoveCar;
        OnMenu += StopGame;
    }

    private void StopGame()
    {
        state = state == GameState.Running ? GameState.Paused : GameState.Running;
    }

    void Update()
    {
        moveDirection = GetInputDirection();
        if (moveDirection != Vector2.zero)
        {
            if(state == GameState.Running)
            {
                OnMove?.Invoke(moveDirection);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(state != GameState.GameOver)
                OnMenu?.Invoke();
        }
    }
   
    private Vector2 GetInputDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction.x += 1;
        }
        if (direction != Vector2.zero)
        {
            direction = direction.normalized;
        }
        return direction;
    }

    private void MoveCar(Vector2 direction)
    {
 
        Vector3 newPosition = transform.position + new Vector3(direction.x, 0, direction.y);
        transform.position = newPosition;
    }
}