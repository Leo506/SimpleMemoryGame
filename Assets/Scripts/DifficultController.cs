using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Difficult
{ 
    public int CountOfRememberCards { get; set; }
    public float TimeToRemember { get; set; }
    public System.Func<float, float> ChangeRememberTime { get; set; }

    public void UpdateTime()
    {
        TimeToRemember = ChangeRememberTime(TimeToRemember);
    }
}


public class DifficultController : MonoBehaviour
{
    private static Dictionary<string, Difficult> difficults = new Dictionary<string, Difficult>()
    {
        { "Easy", new Difficult() { CountOfRememberCards = 3, TimeToRemember = 5, ChangeRememberTime = time => time } },
        { "Normal", new Difficult() { CountOfRememberCards = 5, TimeToRemember = 3, ChangeRememberTime = time => time } },
        { "Hell", new Difficult() { CountOfRememberCards = 5, TimeToRemember = 5, ChangeRememberTime = time => time * 0.85f } }
    };

    public static Difficult currentDifficult { get; private set; }
    public static event System.Action DifficultChoosedEvent;

    public void ChooseDifficult(string id)
    {
        currentDifficult = difficults[id];
        DifficultChoosedEvent?.Invoke();
    }
}
