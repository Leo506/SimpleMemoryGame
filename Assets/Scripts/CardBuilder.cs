using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [Header("Префаб карты")]
    [SerializeField] CardUI cardPrefab;

    [Header("Префаб цели")]
    [SerializeField] CardTarget targetPrefab;

    [Header("Родительские объекты для клонов")]
    [SerializeField] Transform rememberSeqRoot;
    [SerializeField] Transform variantsSeqRoot;
    [SerializeField] Transform targetsRoot;

    [Header("Значения для спавна")]
    [SerializeField] float xOffset;
    [SerializeField] float yForRememberSeq;
    [SerializeField] float yForVariantsSeq;

    List<CardUI> rememberCards;
    List<CardTarget> cardTargets;

    public void BuildGameBoard(CardInfo[] rememberCards, CardInfo[] variantsCards)
    {

        this.rememberCards = new List<CardUI>();
        cardTargets = new List<CardTarget>();

        BuildRememberSeqAndTargets(rememberCards);
        BuildVariantsSeq(variantsCards);
    }

    private void BuildRememberSeqAndTargets(CardInfo[] cards)
    {
        float xPos = -xOffset * (cards.Length / 2);
        for (int i = 0; i < cards.Length; i++, xPos += xOffset)
        {
            var cardObj = Instantiate(cardPrefab, rememberSeqRoot);
            cardObj.transform.localPosition = new Vector2(xPos, yForRememberSeq);
            cardObj.SetValues(canvas, cards[i].CardText, cards[i].CardColor);

            var target = Instantiate(targetPrefab, targetsRoot);
            target.transform.localPosition = new Vector2(xPos, yForRememberSeq);
            target.Link(cards[i]);

            rememberCards.Add(cardObj);
            cardTargets.Add(target);
        }
    }

    private void BuildVariantsSeq(CardInfo[] cards)
    {
        float startX = -xOffset * (cards.Length / 2);
        for (int i = 0; i < cards.Length; i++, startX += xOffset)
        {
            var cardObj = Instantiate(cardPrefab, variantsSeqRoot);
            cardObj.transform.localPosition = new Vector2(startX, yForVariantsSeq);
            cardObj.SetValues(canvas, cards[i].CardText, cards[i].CardColor);
        }
    }

    public List<CardUI> GetRememberCards()
    {
        return rememberCards;
    }

    public List<CardTarget> GetCardTargets()
    {
        return cardTargets;
    }
}
