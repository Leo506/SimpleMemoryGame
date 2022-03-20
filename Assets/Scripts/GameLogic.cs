using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] CardBuilder cardBuilder;
    CardInfo[] toRememberCards;
    CardTarget[] targets;

    // Start is called before the first frame update
    void Start()
    {
        toRememberCards = new CardInfo[5];
        CardInfo[] toUseCards = new CardInfo[7];
        int i;
        for (i = 0; i < 5; i++)
        {
            toRememberCards[i] = CardGenerator.GenerateCard();
            toUseCards[i] = toRememberCards[i];
        }

        for (; i < 7; i++)
            toUseCards[i] = CardGenerator.GenerateCard();

        var random = new System.Random();
        random.Shuffle<CardInfo>(toUseCards);

        cardBuilder.BuildSequence(toUseCards, 250, -318);
        
        targets = cardBuilder.BuildTargets(5);
        LinkTargetToCard();

        StartCoroutine(WaitBeforeHide(cardBuilder.BuildSequence(toRememberCards)));

        CardTarget.CardWasDrop += CheckUserSequence;
    }

    private void LinkTargetToCard()
    {
        for (int i = 0; i < targets.Length; i++)
            targets[i].Link(toRememberCards[i]);
    }

    IEnumerator WaitBeforeHide(List<CardUI> cards)
    {
        yield return new WaitForSeconds(3);
        foreach (var obj in cards)
            obj.gameObject.SetActive(false);
    }

    private void CheckUserSequence()
    {
        foreach (var target in targets)
        {
            if (!target.HaveCorrectCard)
                return;
        }

        Debug.Log("Victory");
    }
}
