using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    Vector3 forward, strafe, vertical;

    private float forwardInput, strafeInput;
    private float forwardSpeed = 3f, strafeSpeed = 3f;

    private float gravity, jumpSpeed;
    private float maxJumpHeight = 2f, timeToMaxHeight = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;
    }

    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
