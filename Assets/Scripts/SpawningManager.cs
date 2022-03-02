using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public GameObject ratPrefab;
    public GameObject catPrefab;
    public float spawnTime = 1.0f;
    private Vector2 cameraBounds;

    // Start is called before the first frame update
    void Start()
    {
        cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ResourcesWave());
    }

    private void SpawnRat()
    {
        GameObject rat = Instantiate(ratPrefab);
        rat.transform.position = new Vector2(cameraBounds.x , Random.Range(-cameraBounds.y, cameraBounds.y * 0.5f));
        
    }

    private void SpawnCat()
    {
        GameObject cat = Instantiate(catPrefab);
        cat.transform.position = new Vector2(Random.Range(cameraBounds.x, cameraBounds.x * 2), Random.Range(-cameraBounds.y, cameraBounds.y * 0.5f));
    }

    IEnumerator ResourcesWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnRat();
            SpawnCat();
        }
    }
}
