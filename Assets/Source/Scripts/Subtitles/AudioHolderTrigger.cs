using UnityEngine;

public class AudioHolderTrigger : MonoBehaviour
{
    [SerializeField] private string _clipName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            FindObjectOfType<AudioManager>().Play(_clipName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            FindObjectOfType<AudioManager>().Stop(_clipName);
        }
    }
}
