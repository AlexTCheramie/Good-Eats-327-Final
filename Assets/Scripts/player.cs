using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int health = 100;                //starting health
    public int score = 0;                   //starting score
    public static int endScore;             //final score (static to be called from end/game over screens)
    public bool isInvincible = false;       //whether the player is invincible
    public  float invincibleTimer = 5.0f;   //how many seconds the invincibility will last

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        endScore = score;   //every update, set the current score to the endScore

        if (health <= 0)    //if the player is dead
        { 
            SceneManager.LoadScene("GameOver");     //load game over screen
        }

        if (Input.GetKey(KeyCode.Escape)){  //if the player presses escape
            SceneManager.LoadScene("End");  //load the end screen
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))     //if the player collides with an enemy
        {
            if (isInvincible == false)          //check whether the player is invincible
            {
                health -= 20;           //lose health
            }
            score -= 20;                //lose score
        }

        if (col.gameObject.CompareTag("superfruit"))        //if the player collides with a super fruit
        {
            score += 50;                                    //add score
            StartCoroutine(invincible(invincibleTimer));    //call coroutine to become invincible using invincible timer
        }

    }

    private IEnumerator invincible(float waitTime)
    {
        isInvincible = true;                        //set the player to invincible
        yield return new WaitForSeconds(waitTime);  //wait for the desired amount of time
        isInvincible = false;                       //set the player back to non-invincible
    }

}
