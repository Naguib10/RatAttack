using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public GameObject resourcePrefab;

    public GameResourcesTypes gameResourcesTypes;

    public float spawnTime = 1.0f;

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float[] rightOrLeft = { 1f, -1f };
    //private float randomPosition;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //randomPosition = rightOrLeft[Random.Range(0, 2)];

        //Invoke("Spawn", spawnTime);
        //StartCoroutine(Spawn());
        //Spawn();
        MoveAround();

    }


    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -screenBounds.x * 1.2 || transform.position.x > screenBounds.x * 1.2)
        {
            Destroy(this.gameObject);
        }
    }

    public void Spawn()
    {
        //----------- This spawn should be for spawning on clicking! not for the automatic spawning------------------------//

        //while (true)
       // {
            //yield return new WaitForSeconds(spawnTime);
            //Instantiate(resourcePrefab, new Vector2(screenBounds.x * randomPosition, Random.Range(-screenBounds.y, screenBounds.y) * 0.5f), Quaternion.identity);

        //}
        
    }

    public void MoveAround()
    {
        speed = Random.Range(6.0f, 12.0f);
        rb = this.GetComponent<Rigidbody2D>();

        if (transform.position.x > 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        } else if (transform.position.x < 0)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        //print(randomPosition);
    }


    public void DestroyResource()
    {
        // destroy resource either in house or pick up from street

        Destroy(this.gameObject);
    }

    public void PlaceInHouse()
    {
        //placing the object in either house by the player
    }


    public enum GameResourcesTypes
    {
        Rat,
        Cat,
        Kid
    }

}
