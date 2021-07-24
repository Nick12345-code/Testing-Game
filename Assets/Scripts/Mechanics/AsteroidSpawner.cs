using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float respawnRate;
    [SerializeField] private GameObject asteroid;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    private void SpawnAsteroid()
    {
        GameObject a = Instantiate(asteroid) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -1, Random.Range(-screenBounds.y, screenBounds.y));
        a.transform.SetParent(GameObject.Find("Clones").transform);
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnRate);
            SpawnAsteroid();
        }
    }
}