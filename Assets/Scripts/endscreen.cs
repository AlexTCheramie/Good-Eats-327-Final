using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour
{
    public Text scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        int finalscore = player.endScore;
        scoreCount.text = "Final Score: " + finalscore.ToString();

    }

    public void returnmain()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
