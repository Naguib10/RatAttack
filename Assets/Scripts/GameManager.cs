using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject rat;
    [SerializeField] GameObject house;
    [SerializeField] GameObject clickedGameObject;
    [SerializeField] Text ratCounterText;

    [SerializeField] int ratCounter = 0;



    // Start is called before the first frame update
    void Start()
    {
        rat = GameObject.Find("Rat");
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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            if (clickedGameObject == rat)
            {
                CollectRat();
            }
            else if (clickedGameObject == house)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    ThrowRat();
                }
            }
        }
    }

    void CollectRat() 
    {
        ratCounter++;
        ratCounterText.text = "Rat Counter: " + ratCounter;
    }

    void ThrowRat() 
    {
        if (ratCounter > 0) 
        {
            ratCounter--;
        }
        ratCounterText.text = "Rat Counter: " + ratCounter;
    }
}
