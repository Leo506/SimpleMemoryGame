using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] string gameSceneName;

    private void Awake()
    {
        DifficultController.DifficultChoosedEvent += LoadGame;
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    private void OnDestroy()
    {
        DifficultController.DifficultChoosedEvent -= LoadGame;
    }
}
