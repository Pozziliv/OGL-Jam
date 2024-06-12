using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private string _clipName;
    [SerializeField] private bool _forStop;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController playerController))
        {
            if (_forStop)
            {
                FindObjectOfType<AudioManager>().Stop(_clipName);
                gameObject.SetActive(false);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play(_clipName);
                gameObject.SetActive(false);
            }
        }
    }
}
