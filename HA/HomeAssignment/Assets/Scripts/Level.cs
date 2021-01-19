using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float wait = 2f;

    [SerializeField] float waitq = 0.5f;

    IEnumerator Load()
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator LoadWin()
    {
        yield return new WaitForSeconds(waitq);
        SceneManager.LoadScene("Win");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2D Game");
    }
    public void LoadGameOver()
    {
        StartCoroutine(Load());
    }
    public void LoadWinner()
    {
        StartCoroutine(LoadWin());
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
