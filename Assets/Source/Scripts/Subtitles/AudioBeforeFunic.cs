using System.Collections;
using UnityEngine;

public class AudioBeforeFunic : MonoBehaviour
{
    [SerializeField] private string _clipName;
    [SerializeField] private Collider _collider;

    private bool _isPlaying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController) && _isPlaying is false)
        {
            FindObjectOfType<AudioManager>().Play(_clipName);
            _isPlaying = true;
            StartCoroutine(DialogueStop());
        }
    }

    private IEnumerator DialogueStop()
    {
        yield return new WaitForSeconds(7f);
        _collider.enabled = true;
        gameObject.SetActive(false);
    }
}
