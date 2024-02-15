/* Charlie Dye - 2024.02.13

This is the script for the base state */

using UnityEngine;

public abstract class PlayerBaseState
{

    public abstract void EnterState(PlayerStateMachine state_machine);

    public abstract void ExitState(PlayerStateMachine state_machine);

    public abstract void UpdateState(PlayerStateMachine state_machine);

    public abstract void FixedUpdateState(PlayerStateMachine state_machine);

    public Vector3 Accelerate(Vector3 wish_dir, Vector3 current_velocity, float accel, float max_speed)
    {

        // Vector3 projection of current velocity (the speed that the player is going)
        float proj_speed = Vector3.Dot(current_velocity, wish_dir);

        // The acceleration component to add
        float accel_speed = accel * Time.deltaTime;

        // Truncates accelerate velocity if needed
        if (proj_speed + accel_speed > max_speed)
        {

            accel_speed = max_speed - proj_speed;

        }

        // Returns new speed
        return current_velocity + (wish_dir * accel_speed);

    }

}
