using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public void OnJump(InputValue value)
    {
        if (!value.isPressed) return;

        GameManager.Instance.HandleJumpInput();
    }
}