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

    public ChamberNumber chamberNumber;

    public InputManager inputManager;


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

            if (inputManager.whichChamber == "PlayerChamber")
            {
                inputManager.ratAtPlayerHouse++;
            }
            else if (inputManager.whichChamber == "EnemyChamber") 
            {
                inputManager.ratAtEnemyHouse++;
            }

        }

    }

    public void PlaceCat()
    {
        if (isRat)
        {
            imageInHouse.sprite = emptySprite;
            isRat = false;

            if (inputManager.whichChamber == "PlayerChamber")
            {
                inputManager.ratAtPlayerHouse--;
            }
            else if (inputManager.whichChamber == "EnemyChamber")
            {
                inputManager.ratAtEnemyHouse--;
            }
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

    public enum ChamberNumber
    {
        p1,
        p2,
        e1
    }
}
