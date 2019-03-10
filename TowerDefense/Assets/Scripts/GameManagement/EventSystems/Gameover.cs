using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {
    bool game_has_ended;

    public GameObject gameOverUI;
    public float time_to_restart;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame()

    {

        if (game_has_ended == false)

        {

            game_has_ended = true;

            Debug.Log("GAME OVER");



            //Bring up Gameover menu

            gameOverUI.SetActive(true);

        }

    }

    public void PressRestart()

    {

        Invoke("Restart", time_to_restart);

    }



    public void Restart()

    {

        //Reload current scene

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Respawn()
    {

    }
}
