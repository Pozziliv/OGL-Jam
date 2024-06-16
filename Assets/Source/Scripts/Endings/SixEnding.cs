using UnityEngine;

public class SixEnding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController characterController))
        {
            FindObjectOfType<QuestsManager>().SixEndStart();
            gameObject.SetActive(false);
        }
    }
}
