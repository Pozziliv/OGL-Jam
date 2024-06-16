using System.Collections;
using UnityEngine;

public class HouseEnding : MonoBehaviour
{
    private float _waitTime = 140f;
    private float _timer = 0f;

    private bool _inHome;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterController playerController))
        {
            _inHome = true;
            _timer = 0f;

            StartCoroutine(WaitingInHome());
        }
    }

    private IEnumerator WaitingInHome()
    {
        int[] phrases = { 0, 0, 0 };

        while (_inHome && _timer <= _waitTime)
        {
            if(_timer > 30f && phrases[0] == 0)
            {
                phrases[0] = 1;
                FindObjectOfType<AudioManager>().Play("Nick19");
            }

            if (_timer > 70f && phrases[1] == 0)
            {
                phrases[1] = 1;
                FindObjectOfType<AudioManager>().Play("Nick20");
            }

            if (_timer > 110f && phrases[2] == 0)
            {
                phrases[2] = 1;
                FindObjectOfType<AudioManager>().Play("Nick21");
            }

            _timer += Time.deltaTime;
            yield return null;
        }

        if(_inHome)
        {
            FindObjectOfType<QuestsManager>().HomeEnd();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CharacterController playerController))
        {
            _inHome = false;
        }
    }
}
