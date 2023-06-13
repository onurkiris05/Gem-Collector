using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void UpdateAnimation(Vector3 direction, float speed)
    {
        var currentSpeed = direction.magnitude * speed;
        _animator.SetFloat("Speed", currentSpeed);
    }
}