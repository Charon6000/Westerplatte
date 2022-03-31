using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void PointerEnter()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.volume = .5f;
        source.Play();
        transform.localScale = new Vector2(1.2f,1.2f);
        transform.localPosition = new Vector2(transform.localPosition.x + 56, transform.localPosition.y);
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1f,1f);
        transform.localPosition = new Vector2(transform.localPosition.x - 56, transform.localPosition.y);
    }
}
