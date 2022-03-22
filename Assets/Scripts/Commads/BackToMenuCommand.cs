using UnityEngine.SceneManagement;

class BackToMenuCommand : ICommand
{
    string menuSceneName;

    public BackToMenuCommand(string sceneName)
    {
        menuSceneName = sceneName;
    }

    public void Execute()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
