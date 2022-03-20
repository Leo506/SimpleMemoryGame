using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] CardBuilder cardBuilder;
    CardTarget[] targets;
    const int MAX_SEQUENCE_LENGTH = 7;

    // Start is called before the first frame update
    void Start()
    {
        var toRememberCards = CreateRememberSequence(5);

        var variantsCards = CreateVariantsSequence(toRememberCards);

        var random = new System.Random();
        random.Shuffle<CardInfo>(variantsCards);

        cardBuilder.BuildGameBoard(toRememberCards, variantsCards);

        StartCoroutine(WaitBeforeHide(cardBuilder.GetRememberCards()));

        CardTarget.CardWasDrop += CheckUserSequence;
    }

    private CardInfo[] CreateRememberSequence(int sequenceLength)
    {
        CardInfo[] toRememberCards = new CardInfo[sequenceLength];
        toRememberCards = new CardInfo[sequenceLength];
        for (int i = 0; i < sequenceLength; i++)
            toRememberCards[i] = CardGenerator.GenerateCard();

        return toRememberCards;
    }

    private CardInfo[] CreateVariantsSequence(CardInfo[] rememberCards)
    {
        CardInfo[] variantsCards = new CardInfo[MAX_SEQUENCE_LENGTH];
        
        for (int i = 0; i < rememberCards.Length; i++)
            variantsCards[i] = rememberCards[i];

        for (int i = rememberCards.Length; i < MAX_SEQUENCE_LENGTH; i++)
            variantsCards[i] = CardGenerator.GenerateCard();

        return variantsCards;
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
