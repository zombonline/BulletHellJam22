using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    static public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    static public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    static public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
