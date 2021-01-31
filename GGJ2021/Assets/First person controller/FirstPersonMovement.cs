using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{

    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode[] runKeys = new KeyCode[] { KeyCode.LeftShift, KeyCode.RightShift };
    public Animator animator;

    Vector2 velocity;
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsKeyPressed(runKeys))
        {
            velocity.x = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            velocity.y = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;

            if (animator) {
                if (velocity.x != 0 || velocity.y != 0) {
                    animator.SetTrigger("Run");
                } else {
                    animator.SetTrigger("Idle");
                }
            }
        }
        else
        {
            velocity.x = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
            velocity.y = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;

            if (animator) {
                if (velocity.x != 0 || velocity.y != 0) {
                    animator.SetTrigger("Walk");
                } else {
                    animator.SetTrigger("Idle");
                }
            }
        }
        transform.Translate(velocity.x, 0, velocity.y);
    }

    static bool IsKeyPressed(KeyCode[] keys)
    {
        // Return true if any of the keys are down.
        for (int i = 0; i < keys.Length; i++) {
            if (Input.GetKey(keys[i])) {
                return true;
            }
        }
        return false;
    }
}
