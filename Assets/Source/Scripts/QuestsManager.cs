using System;
using System.Collections;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    private bool _isStarted = false;

    [SerializeField] private GameObject[] _dinoCheckTriggers;

    [SerializeField] private GameObject[] _rideFunicTriggers;

    private void Start()
    {
        StartCoroutine(Meeting());
    }

    private IEnumerator Meeting()
    {
        FindObjectOfType<AudioManager>().Play("Nick1");

        yield return new WaitForSeconds(8.5f);

        FindObjectOfType<AudioManager>().Play("Nick2");

        yield return new WaitForSeconds(8.5f);

        FindObjectOfType<AudioManager>().Play("Nick3");

        yield return new WaitForSeconds(22.5f);

        yield return new WaitUntil(CheckInput);

        FindObjectOfType<AudioManager>().Play("Nick4");

        yield return new WaitForSeconds(2.5f);

        FindObjectOfType<CharacterController>().enabled = true;

        _isStarted = true;
    }

    private bool CheckInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }

    public void SetDinoCheck()
    {
        foreach (GameObject obj in _dinoCheckTriggers)
        {
            obj.SetActive(false);
        }
    }

    public void CarEnding()
    {
        StartCoroutine(CarMakeBRRRRRRRRRR());
    }

    private IEnumerator CarMakeBRRRRRRRRRR()
    {
        FindObjectOfType<AudioManager>().Play("Nick28");
        yield return null;
    }

    public void SetFuniculerInt(int value)
    {
        if(value == 2)
        {
            _rideFunicTriggers[0].SetActive(true);
        }
        else if (value == 3)
        {
            _rideFunicTriggers[1].SetActive(true);
        }
        else if (value == 4)
        {
            _rideFunicTriggers[2].SetActive(true);
        }
        else if (value == 5)
        {
            _rideFunicTriggers[3].SetActive(true);
        }
        else if (value == 6)
        {
            _rideFunicTriggers[4].SetActive(true);
        }
    }
}
