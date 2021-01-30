using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Transform head;

    [HideInInspector]
    public float defaultHeadYLocalPosition;

    [Tooltip("Capsule collider to lower when we crouch.\nCan be empty.")]
    public CapsuleCollider capsuleCollider;

    [HideInInspector]
    public float defaultCapsuleColliderHeight;

    [SerializeField]
    GroundCheck groundCheck;

    public float crouchYLocalPosition = 1;

    public KeyCode[] keys = new KeyCode[] { KeyCode.LeftControl, KeyCode.RightControl };
    public bool isCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;

    void Start()
    {
        defaultHeadYLocalPosition = head.localPosition.y;
        if (capsuleCollider) {
            defaultCapsuleColliderHeight = capsuleCollider.height;
        }
    }

    void Reset()
    {
        // Get head ( ͡° ͜ʖ ͡°)
        head = GetComponentInChildren<Camera>().transform;

        // Get the capsule collider
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();

        // Get or create the groundCheck object.
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck) {
            groundCheck = GroundCheck.Create(transform);
        }
    }

    void FixedUpdate()
    {
        // Get current head position
        float currentHeight = head.localPosition.y;

        if (IsKeyPressed(keys))
        {
            // Crouch down
            float minHeight = defaultHeadYLocalPosition - crouchYLocalPosition;

            // Enforce crouched y local position animation of the head.
            if (minHeight < currentHeight) {
                head.localPosition = new Vector3(head.localPosition.x, head.localPosition.y - 0.1f, head.localPosition.z);
            }

            // Lower the capsule collider.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight - (defaultHeadYLocalPosition - crouchYLocalPosition);
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Set state.
            if (!isCrouched)
            {
                isCrouched = true;
                CrouchStart?.Invoke();
            }
        }
        else
        {
            // Will the Real Slim Shady please stand up?
            float maxHeight = defaultHeadYLocalPosition;

            // Reset the head to its default y local position.
            if (currentHeight < maxHeight) {
                head.localPosition = new Vector3(head.localPosition.x, head.localPosition.y + 0.1f, head.localPosition.z);
            }

            // Reset the capsule collider's position.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight;
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Reset state.
            isCrouched = false;
            CrouchEnd?.Invoke();
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
