using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private FloatingJoystick variableJoystick;

    public Vector3 GetDirection()
    {
        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            var direction = Vector3.forward * variableJoystick.Vertical +
                            Vector3.right * variableJoystick.Horizontal;
            return direction;
        }
        return Vector3.zero;
    }
}