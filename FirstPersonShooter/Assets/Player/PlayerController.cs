/* Charlie Dye - 2024.01.30

This is the script for the first person player */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // Camera variables
    public Camera main_camera;

    private Vector2 look_input = Vector2.zero;

    private float look_speed = 60f;
    private float horizontal_look_angle = 0f;
    [Range (0.01f, 1f)] public float sensitivity;

    public bool invert_x = false;
    public bool invert_y = false;
    public int invert_factor_x = 1;
    public int invert_factor_y = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Inverts the camera controls
        if (invert_x) invert_factor_x = -1;
        if (invert_y) invert_factor_y = -1;

    }

    // Update is called once per frame
    void Update()
    {

        Look();

    }

    public void GetLookInput(InputAction.CallbackContext context)
    {

        look_input = context.ReadValue<Vector2>();

    }

    private void Look()
    {

        // Looks left and right
        transform.Rotate(Vector3.up, look_input.x * look_speed * Time.deltaTime * invert_factor_x * sensitivity);

        // Looks up and down
        float angle = look_input.y * look_speed * Time.deltaTime * invert_factor_y * sensitivity;
        horizontal_look_angle -= angle;
        horizontal_look_angle = Mathf.Clamp(horizontal_look_angle, -90, 90);
        main_camera.transform.localRotation = Quaternion.Euler(horizontal_look_angle, 0, 0);

    }

}
