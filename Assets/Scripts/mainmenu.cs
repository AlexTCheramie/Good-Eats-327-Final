using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;                          //make cursor visible
        Cursor.lockState = CursorLockMode.None;         //cursor lock
    }
    public void QuitGameButton()        //quit game if player clicks quit button
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartFirstButton()          //load first person scene if player clicks first person button
    {
        SceneManager.LoadScene("FirstPerson");
    }
    public void StartThirdButton()          //load third person scene if player clicks third person button
    {
        SceneManager.LoadScene("ThirdPerson");
    }
}
