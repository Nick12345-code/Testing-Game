using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private AsteroidSpawner asteroidSpawner;
    private PlayerController controller;
    private Score scoreScript;
    private SceneController scene;

    private GameObject currentGame;

    [SetUp]
    public void SetUp()
    {
        GameObject game = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        asteroidSpawner = game.GetComponentInChildren<AsteroidSpawner>();
        controller = game.GetComponentInChildren<PlayerController>();
        scoreScript = game.GetComponentInChildren<Score>();
        game = currentGame;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(currentGame.gameObject);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AsteroidMovesRight()
    {
        // reference to asteroid
        GameObject asteroid = asteroidSpawner.SpawnAsteroid();
        float startXPos = asteroid.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(asteroid.transform.position.x, startXPos);     
    }

    [UnityTest]
    public IEnumerator ScoreIncreasesWhenAsteroidIsDestroyedByBullet()
    {
        GameObject asteroid = asteroidSpawner.SpawnAsteroid();
        GameObject bullet = controller.Shoot();
        int startScore = scoreScript.score;
        asteroid.transform.position = bullet.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(scoreScript.score, startScore);
    }

    [UnityTest]
    public IEnumerator GameOverScreenOpensWhenPlayerHitByAsteroid()
    {
        GameObject asteroid = asteroidSpawner.SpawnAsteroid();
        GameObject player = controller.gameObject;
        asteroid.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.True(scene.gameOver);
    }
    /*
    [UnityTest]
    public IEnumerator PlayerFollowsMousePosition()
    {
        
    }

    [UnityTest]
    public IEnumerator ()
    {
        
    }
    */

}
