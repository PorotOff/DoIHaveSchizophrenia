using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
    private SecurityCameraSwitching cameraSwitching;

    private ICommand command;

    public void Initialise(SecurityCameraSwitching cameraSwitching)
    {
        this.cameraSwitching = cameraSwitching;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            command = new SwitchCameraCommand(cameraSwitching, SwitchingDirections.next);
            command.Execute();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            command = new SwitchCameraCommand(cameraSwitching, SwitchingDirections.previous);
            command.Execute();
        }
    }
}