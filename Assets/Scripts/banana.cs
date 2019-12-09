using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();      //get the audio source
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 5.0f, 0);      //rotate the object

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))        //when player walks into object
        {
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();       
            foreach (Renderer c in allRenderers) c.enabled = false;                         //delete renderer for object's children
            Collider[] allcolliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allcolliders) c.enabled = false;                         //delete collidor for object's children
            StartCoroutine(Play(myaudio.clip.length));                                      //call coroutine with length of audio
        }
    }

    private IEnumerator Play(float waitTime)
    {
        myaudio.Play();                                 //play audio
        yield return new WaitForSeconds(waitTime);      //wait for audio to finish
        Destroy(gameObject);                            //delete object
    }
}
