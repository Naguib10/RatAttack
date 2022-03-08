using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public GameObject resourcePrefab;

    public float spawnTime = 1.0f;

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void Spawn()
    {
        GameObject resource = Instantiate(resourcePrefab);
        resource.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y * 0.5f));
    }

    public void MoveAround()
    {
        speed = Random.Range(6.0f, 12.0f);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    public void DestroyResource()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
