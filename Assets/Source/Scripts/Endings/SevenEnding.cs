using UnityEngine;

public class SevenEnding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController characterController))
        {
            FindObjectOfType<QuestsManager>().SevenEndStart();
        }
    }
}
