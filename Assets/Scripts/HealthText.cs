using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour { 
    public Text hp;             //text to be written
    public player player;       //player to get values


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + player.health.ToString();        //display the health of player

    }
    private void OnTriggerEnter(Collider other)         //handles collisions with fruit (probably would've been better in a different script, but i ended up putting it here)
    {
        if (other.gameObject.CompareTag("melon"))      
        {
            player.health += 10;                        //if player collides with a melon, increase health
        }
        if (other.gameObject.CompareTag("banana"))
        {
            player.health += 5;                     //if the player collides with a banana, increase health
        }
        if (other.gameObject.CompareTag("chips"))
        {
            if(player.isInvincible == false)    
            {
                player.health -= 5;                 //if the player collides with a chip bag and is NOT invincible, decrease health
            }
        }
        if (other.gameObject.CompareTag("icecream"))
        {
            if (player.isInvincible == false)
            {
                player.health -= 10;                //if the player collides with an icecream and is NOT invincible, decrease health
            }
        }
    }

}
