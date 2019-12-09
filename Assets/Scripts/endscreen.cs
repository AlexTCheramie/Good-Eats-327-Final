using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour
{
    public Text scoreCount;     //Text to display

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;                                          //cursor visible
        Cursor.lockState = CursorLockMode.None;                         //cursor lock
        int finalscore = player.endScore;                               //get player's ending score
        scoreCount.text = "Final Score: " + finalscore.ToString();      //display player's final score
            
    }

    public void returnmain()                    //load start menu if player clicks main menu button
    {
        SceneManager.LoadScene("StartMenu");
    }
}
