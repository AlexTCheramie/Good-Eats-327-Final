using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{
    public Text scoretext;
    public player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + player.score.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("melon"))
        {
            player.score += 30;
        }
        if (other.gameObject.CompareTag("banana"))
        {
            player.score += 15;
        }
        if (other.gameObject.CompareTag("chips"))
        {
            player.score -= 5;
        }
        if (other.gameObject.CompareTag("icecream"))
        {
           player.score -= 10;
        }
        scoretext.text = "Score: " + player.score.ToString();
    }
}
