public class PauseCommand : ICommand
{
    CanvasData canvasData;

    public PauseCommand(CanvasData data)
    {
        canvasData = data;
    }

    public void Execute()
    {
        canvasData.mainCanvas.enabled = false;
        canvasData.pauseCanvas.enabled = true;
    }
}
