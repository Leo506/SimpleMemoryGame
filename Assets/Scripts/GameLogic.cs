using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] CardBuilder cardBuilder;

    // Start is called before the first frame update
    void Start()
    {
        CardInfo[] cards = new CardInfo[5];
        for (int i = 0; i < 5; i++)
        {
            cards[i] = CardGenerator.GenerateCard();
        }

        StartCoroutine(WaitBeforeHide(cardBuilder.BuildSequence(cards)));
    }

    IEnumerator WaitBeforeHide(List<GameObject> objs)
    {
        yield return new WaitForSeconds(3);
        foreach (var obj in objs)
            obj.SetActive(false);
    }
}
