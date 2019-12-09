using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour { 
    public Text hp;
    public player player;


    // Start is called before the first frame update
    void Start()
    {
       // hp.text = "HP: " + player.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + player.health.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("melon"))
        {
            player.health += 10;
        }
        if (other.gameObject.CompareTag("banana"))
        {
            player.health += 5;
        }
        if (other.gameObject.CompareTag("chips"))
        {
            player.health -= 5;
        }
        if (other.gameObject.CompareTag("icecream"))
        {
            player.health -= 10;
        }
        hp.text = "HP: " + player.health.ToString();
    }
}
