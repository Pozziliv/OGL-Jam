using System.Collections;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    private bool _isStarted = false;

    [SerializeField] private GameObject[] _dinoCheckTriggers;

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
}
