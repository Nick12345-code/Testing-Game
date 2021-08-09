using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        // creates instance of the game
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        // destroys instance of the game, cleaning up avoids future conflicts
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {
        // creates an asteroid
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        // records the starting position of that asteroid
        float initialYPos = asteroid.transform.position.y;
        // allows time for the asteroid to move
        yield return new WaitForSeconds(0.1f);
        // if asteroids position is now lower than its starting position it moved down
        Assert.Less(asteroid.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        // position of the asteroid and ship are set to the same position to force a collision
        asteroid.transform.position = game.GetShip().transform.position;
        // physics engine requires a passage of time
        yield return new WaitForSeconds(0.1f);
        // checks to make sure that the isGameOver is set to true after this collision
        Assert.True(game.isGameOver);
    }

    [UnityTest]
    public IEnumerator NewGameRestartsGame()
    {
        // sets isGameOver bool to true
        game.isGameOver = true;
        game.NewGame();
        // as NewGame() has been called, this makes sure isGameOver is set to false
        Assert.False(game.isGameOver);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        // spawns a laser
        GameObject laser = game.GetShip().SpawnLaser();
        // records the starting position of that laser
        float initialYPos = laser.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        // makes sure laser y position increased, meaning it moved up
        Assert.Greater(laser.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator LaserDestroysAsteroid()
    {
        // spawns an asteroid and laster and sets their positions equal to force a collision
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // makes sure asteroid was destroyed in that collision
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator DestroyedAsteroidRaisesScore()
    {
        // spawns an asteroid and laster and sets their positions equal to force a collision
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // makes sure score equals 1
        Assert.AreEqual(game.score, 1);
    }

}

