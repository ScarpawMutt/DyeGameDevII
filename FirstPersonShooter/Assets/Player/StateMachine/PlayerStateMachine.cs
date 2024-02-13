/* Charlie Dye - 2024.02.13

This is the script for the state machine */

using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    // State machine variables
    private PlayerBaseState current_state;
    public PlayerGroundState ground_state = new PlayerGroundState();
    public PlayerAirState air_state = new PlayerAirState();

    // Start is called before the first frame update
    void Start()
    {

        current_state = ground_state;
        current_state.EnterState(this);
        
    }

    // Update is called once per frame
    void Update()
    {

        current_state.UpdateState(this);
        
    }

    private void FixedUpdate()
    {
        
        current_state.FixedUpdateState(this);

    }

    public void SwitchState(PlayerBaseState cur_state, PlayerBaseState new_state)
    {

        cur_state.ExitState(this);
        current_state = new_state;
        current_state.EnterState(this);

    }

}
