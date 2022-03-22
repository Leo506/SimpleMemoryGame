using UnityEngine.SceneManagement;

public class NextRoundCommand : ICommand
{
    public void Execute()
    {
        DifficultController.currentDifficult.UpdateTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
