using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    public GameObject canvas;
    public GameObject enemyGenerator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        bool canJunp = canvas.GetComponent<CreateController>().gameState == GameStates.Playing;
        if (canJunp && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)) )
        {
            UpdateState("playerJump");
        }

    }

    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            UpdateState("playerDie");
            canvas.GetComponent<CreateController>().gameState = GameStates.Finish;
            enemyGenerator.SendMessage("CancelGenerator", true);
        }

    }

    void gameReady()
    {
        canvas.GetComponent<CreateController>().gameState = GameStates.Ready;
    }
}
