using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCrossHair : MonoBehaviour
{
    static public float spread = 0;

    public GameObject crosshair;
    GameObject topPart;
    GameObject bottomPart;
    GameObject leftPart;
    GameObject rightPart;

    float initialPosition;

    //Wyszukiwanie odpowiednich części celownika oraz ich początkowych pozycji
    void Start()
    {        
        topPart = crosshair.transform.Find("Up").gameObject;
        bottomPart = crosshair.transform.Find("Down").gameObject;
        leftPart = crosshair.transform.Find("Left").gameObject;
        rightPart = crosshair.transform.Find("Right").gameObject;
        initialPosition = topPart.GetComponent<RectTransform>().localPosition.y;
    }

    void Update()
    {
        // Zmiana pozycji części celownika w zależności od wartości zmiennej 'spread'
        // Jeśli zmienna 'spread' jest większa od 0 wtedy spread zmniejszamy stopniowo
        if (spread != 0)
        {
            topPart.GetComponent<RectTransform>().localPosition = new Vector3(0, initialPosition + spread, 0);
            bottomPart.GetComponent<RectTransform>().localPosition = new Vector3(0, -(initialPosition + spread), 0);
            leftPart.GetComponent<RectTransform>().localPosition = new Vector3(-(initialPosition + spread), 0, 0);
            rightPart.GetComponent<RectTransform>().localPosition = new Vector3(initialPosition + spread, 0, 0);

            if(spread > 10)
            spread -= 4;
        }
    }
}