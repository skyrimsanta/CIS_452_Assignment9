/*
 * (Levi Schoof)
 * (GameManger.cs)
 * (Assignment 9)
 * (Handles the foudatio of the gameplay)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float maxGameTime;
    private float currentGameTime;

    public TextMeshProUGUI timeLeft;

    public GameObject endPanel;
    public TextMeshProUGUI endText;

    public GameObject instructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
        instructionPanel.SetActive(true);
        Time.timeScale = 0;
        currentGameTime = 0;
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(Time.timeScale == 0 & endPanel.activeSelf & Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        PauseMenu();
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (instructionPanel.activeSelf)
            {
                Time.timeScale = 1;
                instructionPanel.SetActive(false);
            }

            else
            {
                Time.timeScale = 0;
                instructionPanel.SetActive(true);
            }
        }
  
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            currentGameTime += Time.deltaTime;
            timeLeft.text = (maxGameTime - currentGameTime).ToString("F2");

            if(currentGameTime >= maxGameTime)
            {
                PlayerWon();
            }
        }
    }

    public void PlayerLost()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
        endText.text = "You Lost :(";
    }

    public void PlayerWon()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
        endText.text = "You Won :)";
    }
}
