using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager1 : MonoBehaviour
{
    public GameResources rat, cat, kid;

    [SerializeField] GameObject clickedGameObject;

    [SerializeField] Text ratCounterText;
    [SerializeField] Text catCounterText;
    [SerializeField] Text kidCounterText;

    [SerializeField] int ratCounter = 0;
    [SerializeField] int catCounter = 0;
    [SerializeField] int kidCounter = 0;

    void Update()
    {
        PlayerControlScheme();
    }

    void PlayerControlScheme() 
    {
        if (Input.GetMouseButtonDown(0))// When clicked Mouse-Left-Button
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);// No need "(Vector2)" in front of ray

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "GameResources")//Use "GameResources" tag name. No transform between clickedGameObject nad tag since here.
                {
                    CollectResource();
                }
                else if (clickedGameObject.tag == "Houses")//Use "Houses" tag name. No transform between clickedGameObject nad tag since here.
                {
                    ThrowResource();
                }
            }
        }
    }

    void CollectResource() //Suppposed to add, Destroy function from Resource class
    {
        /*
         * 
         * If writing as follow by using cast, it works, but it ie better to use Enum instead.
        GameResources gameResource = clickedGameObject.GetComponent<GameResources>();
        Rat rat = (Rat) gameResource;

        if (rat !=null){}

        //cat,kid as well
        */

        /*
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
        */

        GameResources gameResources = clickedGameObject.GetComponent<GameResources>();

        switch (gameResources.gameResourcesTypes)//Using Enum value from GameResources script
        {
            case GameResources.GameResourcesTypes.Rat:
                IncreaseResourceCounter(ratCounter);
                break;

            case GameResources.GameResourcesTypes.Cat:
                IncreaseResourceCounter(catCounter);
                break;

            case GameResources.GameResourcesTypes.Kid:
                IncreaseResourceCounter(kidCounter);
                break;

            default:
                //Debug.Log(clickedGameObject.ToString());
                Debug.Log("Nothing clicked");
                break;
        }

        Destroy(clickedGameObject);

        void IncreaseResourceCounter(int typeOfResouceCounter)
        {
            if (typeOfResouceCounter == ratCounter)
            {
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;
            }
            else if (typeOfResouceCounter == catCounter)
            {
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
            }
            else if (typeOfResouceCounter == kidCounter)
            {
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
            }
        }
    }

    void ThrowResource() //Suppposed to be added, Spawn function from Resource class
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            DecreaseResourceCounter(ratCounter);
            RespwanResourceAtHouse(rat, ratCounter);
        } 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            DecreaseResourceCounter(catCounter);
            RespwanResourceAtHouse(cat, catCounter);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            DecreaseResourceCounter(kidCounter);
            RespwanResourceAtHouse(kid, kidCounter);
        }


        // When using (throuwing) the number of the thrown resouce to be decreased
        void DecreaseResourceCounter(int typeOfResouceCounter) 
        {
            if (typeOfResouceCounter == ratCounter && ratCounter > 0)
            {
                ratCounter--;
                ratCounterText.text = "Rat Counter: " + ratCounter;
            } 
            else if (typeOfResouceCounter == catCounter && catCounter > 0)
            {
                catCounter--;
                catCounterText.text = "Cat Counter: " + catCounter;
            } 
            else if (typeOfResouceCounter == kidCounter && kidCounter > 0) 
            {
                kidCounter--;
                kidCounterText.text = "Kid Counter: " + kidCounter;
            }
        }

        // Respawn captured resource at mouse position (inside of house)
        void RespwanResourceAtHouse(GameResources typeOfResource, int typeOfResouceCounter)
        {
            // Respawn point for captured resource thrown to Houses
            Vector2 respwanResourcePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (typeOfResouceCounter > 0) 
            {
                Instantiate(typeOfResource, respwanResourcePos, Quaternion.identity);
            }
        }
    }
}
