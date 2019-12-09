using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int health = 100;
    public int score = 0;
    public float invincibilityTimer;
    public static int endScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        endScore = score;

        if (health <= 0)
        { 
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("End");
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            health -= 20;
            score -= 20;
        }

    }

}
