using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    public Text gameOverText;
    public PlayerController player;

    int score;
    float gameTimer;
    bool gameOver;

    private void Start()
    {
        Time.timeScale = 1;

        player.OnHitGoomba += OnHitGoomba;
        player.OnHitspike += OnGameOver;
        player.OnHitOrv += OnGameWin;

        scoreText.enabled = true;
        gameOverText.enabled = false;
    }

    private void Update()
    {
        mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, Time.deltaTime * 10.0f),
            Mathf.Lerp(mainCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 10.0f),
            mainCamera.transform.position.z);

        if(gameOver)
        {
            if(Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            return;
        }

        scoreText.text = "Score: " + score;

        if (player.transform.position.y < -10)
            OnGameOver();

    }

    void OnHitGoomba()
    {
        this.score += 100;
    }

    void OnGameOver()
    {
        gameOver = true;

        scoreText.enabled = false;
        gameOverText.enabled = true;
        gameOverText.text = "Game Over!\nPress R to Restart";

        Time.timeScale = 0;
    }

    void OnGameWin()
    {
        gameOver = true;

        scoreText.enabled = false;
        gameOverText.enabled = true;

        gameOverText.text = "You Win!\n Press R to Restart";

        Time.timeScale = 0;
    }




} // main class
