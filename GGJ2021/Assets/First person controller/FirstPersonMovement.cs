using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;

    public KeyCode[] runKeys = new KeyCode[] { KeyCode.LeftShift, KeyCode.RightShift };

    Vector2 velocity;

    void Update()
    {
        if (IsKeyPressed(runKeys))
        {
            velocity.x = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            velocity.y = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
        }
        else
        {
            velocity.x = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
            velocity.y = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
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
