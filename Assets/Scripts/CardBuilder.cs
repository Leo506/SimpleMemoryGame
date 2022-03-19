using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] CardUI cardPrefab;
    [SerializeField] CardTarget targetPrefab;
    [SerializeField] float xOffset;
    [SerializeField] float yCoordinate;
    
    public List<CardUI> BuildSequence(CardInfo[] cards)
    {
        if (cards.Length == 0)
            return null;

        List<CardUI> cardOnScreen = new List<CardUI>();

        float startX = -xOffset * (int)(cards.Length / 2);
        for (int i = 0; i < cards.Length; i++, startX += xOffset)
        {
            var cardObj = Instantiate(cardPrefab, canvas.transform);
            cardObj.transform.localPosition = new Vector2(startX, yCoordinate);
            cardObj.SetValues(canvas, cards[i].CardText, cards[i].CardColor);

            cardOnScreen.Add(cardObj);
        }

        return cardOnScreen;
    }

    public void BuildSequence(CardInfo[] cards, float offset, float vertCoordinate)
    {
        if (cards.Length == 0)
            return;

        float startX = -offset * (int)(cards.Length / 2);
        for (int i = 0; i < cards.Length; i++, startX += xOffset)
        {
            var cardObj = Instantiate(cardPrefab, canvas.transform);
            cardObj.transform.localPosition = new Vector2(startX, vertCoordinate);
            cardObj.SetValues(canvas, cards[i].CardText, cards[i].CardColor);
        }
    }

    public CardTarget[] BuildTargets(int countOfTargets)
    {
        if (countOfTargets <= 0)
            return null;

        CardTarget[] targets = new CardTarget[countOfTargets];

        float startX = -xOffset * (int)(countOfTargets / 2);
        for (int i = 0; i < countOfTargets; i++, startX += xOffset)
        {
            var target = Instantiate(targetPrefab, canvas.transform);
            target.transform.localPosition = new Vector2(startX, yCoordinate);
            targets[i] = target;
        }

        return targets;
    }
}
