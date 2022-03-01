using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject rat;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject kid;
    [SerializeField] GameObject house;
    [SerializeField] GameObject clickedGameObject;
    [SerializeField] string clickedGameObjectTag;

    [SerializeField] Text ratCounterText;
    [SerializeField] Text catCounterText;
    [SerializeField] Text kidCounterText;

    [SerializeField] int ratCounter = 0;
    [SerializeField] int catCounter = 0;
    [SerializeField] int kidCounter = 0;



    // Start is called before the first frame update
    void Start()
    {
        rat = GameObject.Find("Rat");
        cat = GameObject.Find("Cat");
        kid = GameObject.Find("Kid");
        house = GameObject.Find("House");
    }

    // Update is called once per frame
    void Update()
    {
        KeyControle();
    }

    void KeyControle() 
    {
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;
            clickedGameObjectTag = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                clickedGameObjectTag = clickedGameObject.tag;
            }

            if (clickedGameObjectTag == "GameResources")
            {
                Collect();
            }
            else if (clickedGameObject == house)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    Throw();
                }

            }
        }
    }

    void Collect() 
    {

        //string resource = "";

        switch (clickedGameObjectTag)
        {
            case "rat":
                ratCounter++;
                ratCounterText.text = "Rat Counter: " + ratCounter;
                break;

            case "cat":
                catCounter++;
                catCounterText.text = "Cat Counter: " + catCounter;
                break;

            case "kid":
                kidCounter++;
                kidCounterText.text = "Kid Counter: " + kidCounter;
                break;

            /*
            default:
                break;
            */
        }


    }

    void Throw() 
    {
        if (ratCounter > 0) 
        {
            ratCounter--;
        }
        ratCounterText.text = "Rat Counter: " + ratCounter;
    }
}
