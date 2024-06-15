using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    [SerializeField] private Animator _stvol;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterController playerController))
        {
            playerController.enabled = false;

            StartCoroutine(TreeFalling());
        }
    }

    private IEnumerator TreeFalling()
    {
        _stvol.Play("Fall");
        yield return null;
    }
}
