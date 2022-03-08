using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public GameResources gameResource;
    public float spawnTime = 1.0f;
    //private Vector2 screenBounds;

    

    // Start is called before the first frame update
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        gameResource.Spawn();
        StartCoroutine(ResourcesWave());
    }


    IEnumerator ResourcesWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            gameResource.Spawn();
            gameResource.MoveAround();
        }
    }
}
