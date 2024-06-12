using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationName;
    [SerializeField] private bool _flag;
    [SerializeField] private MovingPlatform _platform;

    private void OnTriggerEnter(Collider other)
    {
        if (_platform.IsStarted())
        {
            return;
        }

        _animator.SetBool(_animationName, _flag);
        _flag = !_flag;
    }
}
