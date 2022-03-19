using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTarget : MonoBehaviour, IDropHandler
{
    RectTransform targetTransform;
    CardUI choosedCard;

    private void Awake()
    {
        targetTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On drop");

        if (eventData.pointerDrag != null)
        {
            CardUI card = eventData.pointerDrag.GetComponent<CardUI>();
            card.isChoosed = true;

            if (choosedCard != null)
            {
                choosedCard.isChoosed = false;
                choosedCard.ResetPosition();
                choosedCard.FreezeMovemenet(false);
            }

            choosedCard = card;
            choosedCard.FreezeMovemenet(true);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = targetTransform.anchoredPosition;
        }
    }
}
