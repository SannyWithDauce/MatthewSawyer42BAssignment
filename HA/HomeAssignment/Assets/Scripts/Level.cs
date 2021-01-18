using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float wait = 2f;

    IEnumerator Load()
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2D Game");
    }
    public void LoadGameOver()
    {
        StartCoroutine(Load());
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        print("Quitting the game!");
        Application.Quit();
    }
}
