using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] Text text;
    [SerializeField] Image colorImage;

    RectTransform cardTransform;
    Vector2 startPos;
    Canvas canvas;
    CanvasGroup canvasGroup;
    bool isFreezed = false;

    public bool isChoosed = false;


    /// <summary>
    /// Устанавливает значения на карте
    /// </summary>
    /// <param name="card">Карта</param>
    public void SetValues(Canvas canvas, string text, Color color)
    {
        cardTransform = GetComponent<RectTransform>();
        startPos = cardTransform.anchoredPosition;
        this.canvas = canvas;

        canvasGroup = GetComponent<CanvasGroup>();

        this.text.text = text;
        colorImage.color = color;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        if (!isFreezed)
            canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On drag");
        if (!isFreezed)
            cardTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        if (isFreezed)
            return;

        canvasGroup.blocksRaycasts = true;
        if (!isChoosed)
            ResetPosition();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
    }

    public void ResetPosition()
    {
        cardTransform.anchoredPosition = startPos;
    }

    public void FreezeMovemenet(bool freeze)
    {
        isFreezed = freeze;

        if (freeze)
            canvasGroup.blocksRaycasts = false;
        else
            canvasGroup.blocksRaycasts = true;
    }
}
