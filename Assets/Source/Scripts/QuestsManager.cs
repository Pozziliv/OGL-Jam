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
    }//1

    private IEnumerator CarMakeBRRRRRRRRRR()
    {
        FindObjectOfType<AudioManager>().Play("Nick28");
        _crosshair.SetActive(false);
        _blackScreen.alpha = 1;
        FindObjectOfType<CharacterController>().enabled = false;
        yield return new WaitForSeconds(13f);
        _endingsScreens[0].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
    }//6

    private IEnumerator SixEnding()
    {
        _blackScreen.alpha = 1;
        FindObjectOfType<CharacterController>().enabled = false;
        _crosshair.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Nick27");
        yield return new WaitForSeconds(12f);
        _endingsScreens[5].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SevenEndStart()
    {
        StartCoroutine(SevenEnding());
    }//7

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
            _endingsScreens[6].alpha = 1;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void FourEnd()
    {
        StartCoroutine(FourEnding());
    }//4

    private IEnumerator FourEnding()
    {
        _blackScreen.alpha = 1;
        _crosshair.SetActive(false);
        yield return new WaitForSeconds(5f);
        _endingsScreens[3].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void FunicEndStart()
    {
        StartCoroutine(SecondEnding());
    }//2

    private IEnumerator SecondEnding()
    {
        _blackScreen.alpha = 1;
        _crosshair.SetActive(false);
        yield return new WaitForSeconds(1f);
        _endingsScreens[1].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ThirdEndStart()
    {
        StartCoroutine(ThirdEnding());
    }//3

    private IEnumerator ThirdEnding()
    {
        yield return new WaitForSeconds(16f);
        _blackScreen.alpha = 1;
        _crosshair.SetActive(false);
        yield return new WaitForSeconds(1f);
        _endingsScreens[2].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HomeEnd()
    {
        StartCoroutine(HomeEnding());
    }//5

    private IEnumerator HomeEnding()
    {
        _blackScreen.alpha = 1;
        _crosshair.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Nick40");
        yield return new WaitForSeconds(15f);
        _endingsScreens[4].alpha = 1;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
