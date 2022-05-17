using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manager class for inputs.
/// Uses new Input System.
/// </summary>
public class InputManager : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public int maxJumpCount = 2;

    private Vector2 m_Move;
    private int m_JumpCount;
    private Rigidbody m_Rigidbody;
    private int m_Difficulty;

    public void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_JumpCount = 0;
        m_Difficulty = PlayerPrefs.GetInt("Difficulty");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        var move = new Vector3(direction.x, 0, direction.y);
        var scaledMove = move * Time.fixedDeltaTime * moveSpeed;
        m_Rigidbody.AddForce(scaledMove);
    }

    private void Jump()
    {
        if (m_JumpCount > 0)
        {
            if (m_Difficulty == 0)
            {
                m_Rigidbody.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
            }
            else if (m_Difficulty == 1)
            {
                m_Rigidbody.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            }
        }
        if (m_JumpCount == 0)
        {
            return;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        float temp = context.ReadValue<float>();
        if (temp != 0 && m_JumpCount <= maxJumpCount)
        {
            m_JumpCount++;
            Jump();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Pausing...");
        PauseMenuManager.showPaused();
    }

    public void FixedUpdate()
    {
        if (m_Rigidbody.velocity.magnitude > maxSpeed)
        {
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, maxSpeed);
        }
        Move(m_Move);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RegularPlane"))
        {
            m_JumpCount = 0;
        }
    }
}
