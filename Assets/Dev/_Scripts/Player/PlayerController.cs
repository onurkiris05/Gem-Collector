using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private MovementHandler _moveHandler;
    private InputHandler _inputHandler;
    private AnimationHandler _animationHandler;

    private void Awake()
    {
        _moveHandler = GetComponent<MovementHandler>();
        _inputHandler = GetComponent<InputHandler>();
        _animationHandler = GetComponent<AnimationHandler>();
    }

    private void FixedUpdate()
    {
        _moveHandler.Move(_inputHandler.GetDirection(), speed, turnSpeed);
        _animationHandler.UpdateAnimation(_inputHandler.GetDirection(), speed);
    }
}