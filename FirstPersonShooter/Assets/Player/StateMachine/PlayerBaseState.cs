/* Charlie Dye - 2024.02.13

This is the script for the base state in the machine */

public abstract class PlayerBaseState
{

    public abstract void EnterState(PlayerStateMachine state_machine);

    public abstract void ExitState(PlayerStateMachine state_machine);

    public abstract void UpdateState(PlayerStateMachine state_machine);

    public abstract void FixedUpdateState(PlayerStateMachine state_machine);

}
