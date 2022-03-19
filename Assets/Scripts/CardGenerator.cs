using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardInfo
{
    public string CardText { get; set;}
    public Color CardColor { get; set; }

    public CardInfo(string text, Color color)
    {
        CardText = text;
        CardColor = color;
    }
}



public class CardGenerator
{
    private static Color[] availableColors = new Color[]
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow
        };

    public static CardInfo GenerateCard()
    {
        var color = availableColors[Random.Range(0, availableColors.Length)];
        var text = Random.Range(0, 11).ToString();

        return new CardInfo(text, color);
    }
}
