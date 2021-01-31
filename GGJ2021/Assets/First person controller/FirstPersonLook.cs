using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;

    public Texture2D cursor;
    public float cursorSize = 20;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotX = 0.0f; // rotation around the right/x axis
    private float rotY = 0.0f; // rotation around the up/y axis

    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotX = transform.localRotation.eulerAngles.x;
        rotY = character.transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion headRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        transform.localRotation = headRotation;

        Quaternion bodyRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        character.transform.rotation = bodyRotation;
    }

    void OnGUI()
    {
        float x = (Screen.width / 2) - (cursorSize / 2);
        float y = (Screen.height / 2) - (cursorSize / 2);
        GUI.DrawTexture(new Rect(x, y, cursorSize, cursorSize), cursor);
    }
}
