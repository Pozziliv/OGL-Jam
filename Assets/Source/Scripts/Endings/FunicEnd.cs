using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunicEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController characterController))
        {
            FindObjectOfType<QuestsManager>().FunicEndStart();
        }
    }
}
