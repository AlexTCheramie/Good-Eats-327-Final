using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDisance = 20.0f;

    AudioSource myaudio;
    ParticleSystem explode;
    bool isdie = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        myaudio = GetComponent<AudioSource>();
        explode = transform.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < chaseDisance)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allcolliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allcolliders) c.enabled = false;

            player.GetComponent<ScoreText>().player.score += 100;
            player.GetComponent<HealthText>().player.health += 10;

            StartCoroutine(Playdeath(myaudio.clip.length));
            gameObject.GetComponent<ParticleSystemRenderer>().enabled = true;
            startdie();
        }

    }
    private IEnumerator Playdeath(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        stopdie();
        Destroy(gameObject);
    }

    private void startdie()
    {
        if (isdie == false)
        {
            explode.Play();
            isdie = true;
        }
    }

    private void stopdie()
    {
        isdie = false;
        explode.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
