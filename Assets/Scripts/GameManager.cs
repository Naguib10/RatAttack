using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject clickedGameObject;

    [SerializeField] Text ratCounterText;
    [SerializeField] Text catCounterText;
    [SerializeField] Text kidCounterText;

    [SerializeField] int ratCounter = 0;
    [SerializeField] int catCounter = 0;
    [SerializeField] int kidCounter = 0;

    // Update is called once per frame
    void Update()
    {
        ControlScheme();
    }

    void ControlScheme() 
    {
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "GameResources")
                {
                    Collect();
                }
                else if (clickedGameObject.tag == "Target")
                {
                    Throw();
                }
            }
        }
    }

    void Collect() 
    {
        switch (clickedGameObject.name)
        {
            case "Rat":
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;
                break;

            case "Cat":
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case "Kid":
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            default:
                Debug.Log(clickedGameObject.ToString());
                break;
        }
    }

    void Throw() 
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (ratCounter > 0)
            {
                ratCounter--;
                ratCounterText.text = "Rat Counter: " + ratCounter;
            }
        } 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (catCounter > 0)
            {
                catCounter--;
                catCounterText.text = "Cat Counter: " + catCounter;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (kidCounter > 0)
            {
                kidCounter--;
                kidCounterText.text = "Kid Counter: " + kidCounter;
            }
        }
    }
}
