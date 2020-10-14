using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public int timeToEnd;

    private bool isPaused = false;
    private bool gameEnded = false;
    private bool gameWon = false;

    private void EndGame()
    {
        CancelInvoke("Stopper");

        if(gameWon)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }
    }

    private void PauseGame()
    {
        Debug.Log("Game Paused");
        isPaused = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Debug.Log("Game Resumed");
        isPaused = false;
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            gameEnded = true;
            EndGame();
        }
    }
}
