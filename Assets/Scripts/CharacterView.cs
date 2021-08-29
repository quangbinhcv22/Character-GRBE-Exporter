using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [Header("Images")] public Image faceImage;
    public Image hairImage;
    public Image bodyImage;
    public Image handImage;
    public Image legImage;
    public Image decoImage;

    [Header("Text")] public TextMeshProUGUI characterIDText;

    public void UpdateView(string faceID, string hairID, string bodyID, string handID, string legID, string decoID)
    {
        faceImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(faceID);
        hairImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(hairID);
        bodyImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(bodyID);
        handImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(handID);
        legImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(legID);
        decoImage.sprite = SpriteManager.Instance.GetSpriteBasedOnID(decoID);

        characterIDText.text = $"{faceID}-{hairID}-{bodyID}-{handID}-{legID}-{decoID}";

        // change index children deco based on ID
        switch ((Element) CharacterID.GetIndexBasedOnElementPosition(decoID, ElementIndexOfBodyPartID.Element))
        {
            case Element.Water:
                decoImage.gameObject.transform.SetSiblingIndex(5);
                break;
            case Element.Fire:
                decoImage.gameObject.transform.SetSiblingIndex(2);
                break;
        }
    }


    private const float RatioBetweenBackgroundAndElements = 512f / 400f;

    public void ChangeSize(int newSize)
    {
        var sizeBackground = new Vector2(newSize, newSize);
        var sizeComponents = new Vector2(newSize, newSize) * RatioBetweenBackgroundAndElements;

        gameObject.GetComponent<RectTransform>().sizeDelta = sizeBackground;

        faceImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
        hairImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
        bodyImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
        handImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
        legImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
        decoImage.GetComponent<RectTransform>().sizeDelta = sizeComponents;
    }
}