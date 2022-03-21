class UnpauseCommand : ICommand
{
    CanvasData canvasData;

    public UnpauseCommand(CanvasData data)
    {
        canvasData = data;
    }

    public void Execute()
    {
        canvasData.mainCanvas.enabled = true;
        canvasData.pauseCanvas.enabled = false;
    }
}
