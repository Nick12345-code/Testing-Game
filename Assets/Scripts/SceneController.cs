using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool gameOver;

    public void ChangeScene(string scene)
    {
        gameOver = false;
        SceneManager.LoadScene(scene);
    }
}
