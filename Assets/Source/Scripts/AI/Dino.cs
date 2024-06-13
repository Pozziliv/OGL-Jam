using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Dino : MonoBehaviour
{
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _stvol;

    private void Start()
    {
        _agent.speed = 3f;
    }

    public void Interract()
    {
        StartCoroutine(AnimationToLeave());
    }

    private IEnumerator AnimationToLeave()
    {
        _animator.Play("Pat");

        yield return new WaitForSeconds(3.42f);
        
        _animator.Play("Runing");

        _agent.SetDestination(_finishPoint.position);

        yield return new WaitForSeconds(1f);

        FindObjectOfType<AudioManager>().Play("Nick14");
        //FindObjectOfType<QuestsManager>().SetDinoCheck();

        yield return new WaitForSeconds(3f);

        _stvol.Play("Fall");

        yield return new WaitForSeconds(6f);

        _animator.Play("Idle");
    }
}
