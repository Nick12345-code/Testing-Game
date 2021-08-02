using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private AsteroidSpawner asteroidSpawner;

    [SetUp]
    public void SetUp()
    {
        GameObject go = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        asteroidSpawner = go.GetComponentInChildren<AsteroidSpawner>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(asteroidSpawner.gameObject);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AsteroidsMoveRight()
    {   
        // grab reference to asteroid itself
        GameObject asteroid = asteroidSpawner.SpawnAsteroid();
        float startXPos = asteroid.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(asteroid.transform.position.x, startXPos);     
    }
}
