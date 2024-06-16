using System.Collections;
using UnityEngine;

public class TowerEndingTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _nose;

    private float _waitTime = 3 * 60f + 40f;
    private float _timer = 0f;

    private bool _onTower;

    public void StartWait()
    {
        _onTower = true;
        _timer = 0f;

        StartCoroutine(WaitingOnTower());
    }

    private IEnumerator WaitingOnTower()
    {
        int[] phrases = { 0, 0, 0, 0};

        while (_onTower && _timer <= _waitTime)
        {
            if (_timer > 30f && phrases[0] == 0)
            {
                phrases[0] = 1;
                FindObjectOfType<AudioManager>().Play("Nick35");
            }

            if (_timer > 70f && phrases[1] == 0)
            {
                phrases[1] = 1;
                FindObjectOfType<AudioManager>().Play("Nick36");
            }

            if (_timer > 110f && phrases[2] == 0)
            {
                phrases[2] = 1;
                FindObjectOfType<AudioManager>().Play("Nick37");

                FindObjectOfType<CharacterController>().enabled = false;
                _nose.GetComponent<InteractiveCommands>().HideInteractiveMessage();
                _nose.SetActive(false);
                FindObjectOfType<HeadBob>().StopAllCoroutines();
            }

            if (_timer > 140f && phrases[3] == 0)
            {
                phrases[3] = 1;
                FindObjectOfType<AudioManager>().Play("Nick38");
            }

            _timer += Time.deltaTime;
            yield return null;
        }
    }

    public void EndWait()
    {
        _onTower = false;
    }
}
