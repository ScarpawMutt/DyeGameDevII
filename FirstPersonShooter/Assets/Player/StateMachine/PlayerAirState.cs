/* Charlie Dye - 2024.02.13

This is the script for the air state */

using UnityEngine;

public class PlayerAirState : PlayerBaseState
{

    public float max_speed = 6f;
    public float acceleration = 60f;
    public float gravity = 15f;

    public override void EnterState(PlayerStateMachine state_machine)
    {
       
        

    }

    public override void ExitState(PlayerStateMachine state_machine)
    {

        state_machine.player_velocity.y = -2;

    }

    public override void UpdateState(PlayerStateMachine state_machine)
    {



    }

    public override void FixedUpdateState(PlayerStateMachine state_machine)
    {

        // Set gravity
        state_machine.player_velocity.y -= gravity * Time.deltaTime;

        // Set velocity
        state_machine.player_velocity = MoveAir(state_machine.wish_dir, state_machine.player_velocity);

        // Switch states
        if (state_machine.character_controller.isGrounded)
        {

            state_machine.SwitchState(this, state_machine.ground_state);

        }

    }

    private Vector3 MoveAir(Vector3 wish_dir, Vector3 current_velocity)
    {

        return Accelerate(wish_dir, current_velocity, acceleration, max_speed);

    }

}
