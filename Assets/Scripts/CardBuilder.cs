using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] float xOffset;
    [SerializeField] float yCoordinate;
    
    public List<GameObject> BuildSequence(CardInfo[] cards)
    {
        if (cards.Length == 0)
            return null;

        List<GameObject> cardOnScreen = new List<GameObject>();

        float startX = -xOffset * (int)(cards.Length / 2);
        for (int i = 0; i < cards.Length; i++, startX += xOffset)
        {
            var cardObj = Instantiate(cardPrefab, canvas.transform);
            cardObj.transform.localPosition = new Vector2(startX, yCoordinate);

            cardOnScreen.Add(cardObj);
        }

        return cardOnScreen;
    }
}
