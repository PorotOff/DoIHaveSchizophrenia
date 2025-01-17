public class SwitchCameraCommand : ICommand
{
    private SecurityCameraSwitching cameraSwithcing { get; set; }
    private SwitchingDirections switchingDirection { get; set; }

    public SwitchCameraCommand(SecurityCameraSwitching cameraSwithcing, SwitchingDirections switchingDirection)
    {
        this.cameraSwithcing = cameraSwithcing;
        this.switchingDirection = switchingDirection;
    }

    public void Execute()
    {
        cameraSwithcing.SwitchCamera(switchingDirection);
    }
}