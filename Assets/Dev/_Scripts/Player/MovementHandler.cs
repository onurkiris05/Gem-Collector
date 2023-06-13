using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed, float turnSpeed)
    {
        if (direction == Vector3.zero) return;
        
        _rb.MovePosition(transform.position + direction * (speed * Time.deltaTime));
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
}