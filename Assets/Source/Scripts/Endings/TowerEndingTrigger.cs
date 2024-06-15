using System.Collections;
using UnityEngine;

public class TowerEndingTrigger : MonoBehaviour
{
    private float _waitTime = 3 * 60f + 40f;
    private float _timer = 0f;

    private bool _onTower;

    public void StartWait()
    {
        _onTower = true;
        _timer = 0f;
    }

    private IEnumerator WaitingOnTower()
    {
        while (_onTower)
        {
            yield return null;
        }
    }

    public void EndWait()
    {
        _onTower = false;
    }
}
