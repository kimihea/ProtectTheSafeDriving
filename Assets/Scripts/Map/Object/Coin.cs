using UnityEngine;

public class coin: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.money++;
        AudioManager.Instance.PlayEffect("Effect/DM-CGS-28");
        Destroy(gameObject);
    }
}