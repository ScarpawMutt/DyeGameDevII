/* Charlie Dye - 2024.02.29

This is the script for guns */

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;

public class Gun : MonoBehaviour
{

    // Gun variables
    public GunData gun_data;
    public Camera cam;
    protected Ray ray;

    // Ammo
    protected int ammo_in_clip;

    // Shooting
    protected bool primary_fire_is_shooting = false;
    protected bool primary_fire_hold = false;

    protected float shoot_delay_timer = 0f;

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

        // Subtract from the timer
        if (shoot_delay_timer > 0f)
        {

            shoot_delay_timer -= Time.deltaTime;

        }

        PrimaryFire();

    }

    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {

        // Check for initial button press
        if (context.phase == InputActionPhase.Started)
        {

            primary_fire_is_shooting = true;

        }

        // Check if it is automatic
        if (gun_data.automatic)
        {

            // Check if hold interaction was complete
            if (context.interaction is HoldInteraction && context.phase == InputActionPhase.Performed)
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

    protected virtual void PrimaryFire()
    {



    }

    protected virtual void SecondaryFire()
    {



    }

}
