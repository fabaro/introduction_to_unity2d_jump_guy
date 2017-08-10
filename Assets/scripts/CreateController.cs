using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStates { Idle, Playing, Finish, Ready};

public class CreateController : MonoBehaviour {

    [Range(0f, 0.20f)] 
    public float parallaxSpeed = 0.02f;

    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;
    public GameObject player;
    public GameObject enemyGenerator;

    public GameStates gameState = GameStates.Idle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Inicio de Juego
        if (gameState == GameStates.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameStates.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "playerRun");
            enemyGenerator.SendMessage("StartGenerator");

        }
        else if (gameState == GameStates.Playing)
        {
            ParallaxMove();
        }
        else if (gameState == GameStates.Ready && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            RestartGame();
        }

        
    }

    void ParallaxMove()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("introduction_to_unity2d");
    }
}
