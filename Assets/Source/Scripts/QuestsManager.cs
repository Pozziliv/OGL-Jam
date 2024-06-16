using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class QuestsManager : MonoBehaviour
{
    private bool _isStarted = false;

    [SerializeField] private GameObject[] _dinoCheckTriggers;

    [SerializeField] private GameObject[] _rideFunicTriggers;
    [SerializeField] private GameObject[] _towerCheckTriggers;

    [SerializeField] private CanvasGroup _blackScreen;
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private CanvasGroup[] _endingsScreens;
    [SerializeField] private Transform _goBack;

    private int _sevenEndingCounter = 0;

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
    public void SetTowerCheck()
    {
        foreach (GameObject obj in _towerCheckTriggers)
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
        _blackScreen.alpha = 1;
        FindObjectOfType<CharacterController>().enabled = false;
        yield return new WaitForSeconds(13f);
        _endingsScreens[0].alpha = 1;
    }

    public void SetFuniculerInt(int value)
    {
        if (value == 2)
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

    public void SixEndStart()
    {
        StartCoroutine(SixEnding());
    }

    private IEnumerator SixEnding()
    {
        _blackScreen.alpha = 1;
        FindObjectOfType<CharacterController>().enabled = false;
        _crosshair.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Nick27");
        yield return new WaitForSeconds(12f);
        _endingsScreens[5].alpha = 1;
    }

    public void SevenEndStart()
    {
        StartCoroutine(SevenEnding());
    }

    private IEnumerator SevenEnding()
    {
        _blackScreen.alpha = 1;
        _sevenEndingCounter += 1;
        var player = FindObjectOfType<CharacterController>();
        player.enabled = false;
        _crosshair.SetActive(false);

        if (_sevenEndingCounter == 1)
        {
            FindObjectOfType<AudioManager>().Play("Nick26");
            yield return new WaitForSeconds(6f);
            player.transform.position = _goBack.position;
            player.enabled = true;
            _blackScreen.alpha = 0;
        }

        if (_sevenEndingCounter == 2)
        {
            FindObjectOfType<AudioManager>().Play("Nick44");
            yield return new WaitForSeconds(5f);
            player.transform.position = _goBack.position;
            player.enabled = true;
            _blackScreen.alpha = 0;
        }

        if (_sevenEndingCounter == 3)
        {
            FindObjectOfType<AudioManager>().Play("Nick45");
            yield return new WaitForSeconds(8f);
            player.transform.position = _goBack.position;
            player.enabled = true;
            _blackScreen.alpha = 0;
        }

        if (_sevenEndingCounter == 4)
        {
            FindObjectOfType<AudioManager>().Play("Nick46");
            yield return new WaitForSeconds(10f);
            _endingsScreens[0].alpha = 1;
        }
    }
}
