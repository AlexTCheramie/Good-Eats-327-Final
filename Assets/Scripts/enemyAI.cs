using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enemyAI : MonoBehaviour
{
    GameObject player;                  //player object
    NavMeshAgent agent;                 //this object
    public float chaseDisance = 20.0f;  //radius for player detection

    AudioSource myaudio;            //audio source
    ParticleSystem explode;         //particle system
    bool isdie = false;             //check to see if enemy is killed

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");          //get player
        agent = this.GetComponent<NavMeshAgent>();          //get this object
        myaudio = GetComponent<AudioSource>();                  //get audio source
        explode = transform.GetComponent<ParticleSystem>();     //get particle system
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < chaseDisance) //if player comes in range, chase them
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))                                            //if hit by a bullet
        {
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();       
            foreach (Renderer c in allRenderers) c.enabled = false;                         //delete renderer for object's children
            Collider[] allcolliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allcolliders) c.enabled = false;                         //delete collidor for object's children

            player.GetComponent<ScoreText>().player.score += 100;       //increase player score
            player.GetComponent<HealthText>().player.health += 10;      //increase player health

            StartCoroutine(Playdeath(myaudio.clip.length));                         //call coroutine with audio length
            gameObject.GetComponent<ParticleSystemRenderer>().enabled = true;       //enable particle system's renderer
            startdie();     //start the death
        }

    }
    private IEnumerator Playdeath(float waitTime)
    {
        myaudio.Play();                                 //play audio
        yield return new WaitForSeconds(waitTime);      //wait for audio to finish
        stopdie();                                      //end
        Destroy(gameObject);                            //destroy game object
    }

    private void startdie()         
    {
        if (isdie == false)                 //if the object is dying
        {   
            explode.Play();                 //play particle system
            isdie = true;                   //set boolean to true
        }
    }

    private void stopdie()
    {
        isdie = false;          //set boolean to false
        explode.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);    //stop particle system
    }
}
