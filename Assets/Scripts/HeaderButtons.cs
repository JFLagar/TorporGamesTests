using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderButtons : MonoBehaviour
{
    public Image buttonImage;
    public Sprite[] buttonSprite;
    public RectTransform content;
    public RectTransform otherContent;

    // Update is called once per frame
    void Update()
    {
        if (content.gameObject.activeSelf)
            buttonImage.sprite = buttonSprite[1];
        else
            buttonImage.sprite = buttonSprite[0];
    }
    public void OpenContent()
    {
        content.gameObject.SetActive(true);
        otherContent.gameObject.SetActive(false);
    }
}
