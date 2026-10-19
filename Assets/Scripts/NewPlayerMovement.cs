using UnityEngine;
using UnityEngine.InputSystem;
public class NewPlayerMovement : MonoBehaviour
{
    Vector2 movePlayer;
    Rigidbody2D playerRigidbody2D;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerJump = 3f;
    InputAction moveAction;
    InputAction jumpAction;
    BoxCollider2D feetCollider;
    bool isAlive = true;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (isAlive)
        {
            TestMove();
        }
    }
    public void OnMove(InputValue value)
    {
        movePlayer = value.Get<Vector2>();
    }
    public void OnJump(InputValue value) 
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Debug.Log("cant jump");
            return;
        }
        if (!isAlive)
        {
            return;
        }
        if (value.isPressed)
        {
            playerRigidbody2D.linearVelocity += new Vector2(0f, playerJump);
        }
    }
    void TestMove()
    {
        Vector2 playerPosition = new Vector2(movePlayer.x * playerSpeed, playerRigidbody2D.linearVelocity.y);
        playerRigidbody2D.linearVelocity = playerPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Player is dead");
            isAlive = false;
        }
    }
}