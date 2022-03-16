using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject clickedGameObject;
    //public GameResources gameResources = FindObjectOfType<GameResources>();

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
        if (Input.GetMouseButtonDown(0))// When clicked Mouse-Left-Button
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);// No need "(Vector2)" in front of ray

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.GetComponent<GameResources>())//Use "Resource" tag name. No transform between clickedGameObject nad tag since here.
                {
                    Collect();
                }
                else if (clickedGameObject.GetComponent<Houses>())//Use "House" tag name. No transform between clickedGameObject nad tag since here.
                {
                    //Debug.Log(clickedGameObject.ToString());
                    Throw();
                }
            }
        }
    }

    void Collect() //Suppposed to add, Destroy function from Resource class
    {
        /*
         * 
         * If writing as follow by using cast, it works, but it ie better to use Enum instead.
        GameResources gameResource = clickedGameObject.GetComponent<GameResources>();
        Rat rat = (Rat) gameResource;

        if (rat !=null){}

        //cat,kid as well
        */


        switch (clickedGameObject.tag)// <-- Need to change!! Use Enum value in "Resource" class.
        {
           
            case "Rat":
                //clickedGameObject..DestroyResource();
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
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }
        

        /*
        GameResources gameResources = clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)
        {
            case GameResources.GameResourcesTypes.Rat:
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;
                break;

            case GameResources.GameResourcesTypes.Cat:
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case GameResources.GameResourcesTypes.Kid:
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            default:
                Debug.Log(clickedGameObject.ToString());
                break;
        }
        */
    }

    void Throw() //Suppposed to be added, Spawn function from Resource class
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
