/* Charlie Dye - 2024.02.27

This is the script for the pistol */

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;

public class Pistol : MonoBehaviour
{

    // Gun variables
    public GunData gun_data;
    public Camera cam;
    private Ray ray;

    // Ammo
    private int ammo_in_clip;

    // Shooting
    private bool primary_fire_is_shooting = false;
    private bool primary_fire_hold = false;

    // Debug
    public TMP_Text debug_text;

    // Start is called before the first frame update
    void Start()
    {
      
        ammo_in_clip = gun_data.ammo_per_clip;

    }

    // Update is called once per frame
    void Update()
    {

        debug_text.text = "Ammo In Clip: " + ammo_in_clip.ToString();

    }

    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {

        // Check for initial button press
        if (context.phase == InputActionPhase.Started)
        {

            primary_fire_is_shooting = true;

        }

        // Check if it is automatic
        if(gun_data.automatic)
        {

            // Check if hold interaction was complete
            if(context.interaction is HoldInteraction && context.phase == InputActionPhase.Performed)
            {

                primary_fire_hold = true;

            }

        }

        // Check if button was released
        if (context.phase == InputActionPhase.Canceled)
        {

            primary_fire_is_shooting = false;
            primary_fire_hold = false;

        }

    }

    public void GetSecondaryFireInput(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started) SecondaryFire();

    }

    private void PrimaryFire()
    {

        // Raycast
        ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, gun_data.range))
        {

            Debug.DrawRay(transform.position, hit.point, Color.green, 0.05f);

        }

        // Subtract ammo
        ammo_in_clip--;
        if (ammo_in_clip <=0)
        {

            ammo_in_clip = gun_data.ammo_per_clip;

        }

    }

    private void SecondaryFire()
    {



    }

}
