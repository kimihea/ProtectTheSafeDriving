using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public GameObject Endpanel;
    public InputManager InputManager;

    void Awake()
    {
        InputManager = GetComponentInParent<InputManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Endpanel.SetActive(true);
        }
    }
}
