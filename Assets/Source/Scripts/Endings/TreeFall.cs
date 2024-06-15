using System.Collections;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    [SerializeField] private Animator _stvol;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterController playerController))
        {
            playerController.enabled = false;
            FindObjectOfType<HeadBob>().StopAllCoroutines();
            StartCoroutine(TreeFalling());
        }
    }

    private IEnumerator TreeFalling()
    {
        _stvol.Play("Fall");
        _stvol.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.7f);
        Debug.Log("dad");
    }
}
