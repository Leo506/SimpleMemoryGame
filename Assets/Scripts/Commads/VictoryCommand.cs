public class VictoryCommand : ICommand
{
    CanvasData canvasData;

    public VictoryCommand(CanvasData data)
    {
        canvasData = data;
    }

    public void Execute()
    {
        canvasData.mainCanvas.enabled = false;
        canvasData.victoryCanvas.enabled = true;
    }
}
