using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{
    public Text scoretext;  //text to be written
    public player player;   //player to get values

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + player.score.ToString();   //text to display to UI

    }
    private void OnTriggerEnter(Collider other)         //handles collisions with fruit (probably would've been better in a different script, but i ended up putting it here)
    {
        if (other.gameObject.CompareTag("melon"))
        {
            player.score += 30;                 //if the player collides with a melon, increase score
        }
        if (other.gameObject.CompareTag("banana"))
        {
            player.score += 15;                 //if the player collides with a banana, increase score
        }
        if (other.gameObject.CompareTag("chips"))
        {
            player.score -= 5;                  //if the player collides with a chip bag, decrease score
        }
        if (other.gameObject.CompareTag("icecream"))
        {
           player.score -= 10;                  //if the player collides with a icecream, decrease score
        }
    }

}
