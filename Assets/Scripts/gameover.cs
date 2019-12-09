using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public Text scoreCount; //text to display

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;                                          //cursor visible
        Cursor.lockState = CursorLockMode.None;                         //cursor lock
        int finalscore = player.endScore;                               //get the player's end score
        scoreCount.text = "Final Score: " + finalscore.ToString();      //display the player's end score
    }

    public void returnmain()        //load the start menu if player clicks main menu button
    {
        SceneManager.LoadScene("StartMenu");
    }
}
