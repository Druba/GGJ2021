using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{

    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode[] runKeys = new KeyCode[] { KeyCode.LeftShift, KeyCode.RightShift };
    public Animator animator;

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
	    rigidBody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		Vector3 currentVelocity = rigidBody.velocity;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 movementDirection = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z) * movement;

        if (IsKeyPressed(runKeys))
        {
            Vector3 velocityChange = (movementDirection * runSpeed - currentVelocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -10.0f, 10.0f);
            velocityChange.y = 0.0f;
            velocityChange.z = Mathf.Clamp(velocityChange.z, -10.0f, 10.0f);
            rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);

            if (animator) {
                if (moveHorizontal != 0 || moveVertical != 0) {
                    animator.SetTrigger("Run");
                } else {
                    animator.SetTrigger("Idle");
                }
            }
        }
        else
        {
            Vector3 velocityChange = (movementDirection * walkSpeed - currentVelocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -10.0f, 10.0f);
            velocityChange.y = 0.0f;
            velocityChange.z = Mathf.Clamp(velocityChange.z, -10.0f, 10.0f);
            rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);

            if (animator) {
                if (moveHorizontal != 0 || moveVertical != 0) {
                    animator.SetTrigger("Walk");
                } else {
                    animator.SetTrigger("Idle");
                }
            }
        }
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
