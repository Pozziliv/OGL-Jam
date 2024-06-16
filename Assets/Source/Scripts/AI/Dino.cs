using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Dino : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
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

        _agent.SetDestination(_points[0].position);

        yield return new WaitForSeconds(1f);

        FindObjectOfType<AudioManager>().Play("Nick14");
        FindObjectOfType<QuestsManager>().SetDinoCheck();

        yield return new WaitForSeconds(3f);

        _stvol.Play("Fall");
        _stvol.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2.5f);

        FindObjectOfType<AudioManager>().Play("Nick15");

        yield return new WaitForSeconds(3.5f);

        _animator.Play("Idle");
    }
}
