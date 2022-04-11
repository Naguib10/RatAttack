using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceImageUpdate : MonoBehaviour
{
    public Image imageInHouse = null;
    public Sprite ratSprite;
    public Sprite catSprite;
    public Sprite kidSprite;
    public Sprite emptySprite;

    public bool isRat, isCat, isKid;


    public void PlaceRat()
    {
        if (isKid)
        {
            imageInHouse.sprite = emptySprite;
            isKid = false;
        }
        else if (!isKid)
        {
            imageInHouse.sprite = ratSprite;
            isRat = true;
        }

    }

    public void PlaceCat()
    {
        if (isRat)
        {
            imageInHouse.sprite = emptySprite;
            isRat = false;
        }
        else if (!isRat)
        {
            imageInHouse.sprite = catSprite;
            isCat = true;
        }

    }

    public void PlaceKid()
    {
        if (isCat)
        {
            imageInHouse.sprite = emptySprite;
            isCat = false;
        }
        else if (!isCat)
        {
            imageInHouse.sprite = kidSprite;
            isKid = true;
        }


    }
}
