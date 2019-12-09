using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class bullet : MonoBehaviour
{
    public GameObject Bullet;               //bullet object
    public float BulletForce = 100.0f;      //force of bullet
    public float destroyTime = 3.0f;        //time until bullet gets destroyed
    AudioSource myaudio;                    //audio source
    private ParticleSystem gunshot;         //particle system for when bullet gets shot
    private bool RT_used = false;           //boolean

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();                                      //get audio source
        gunshot = GameObject.Find("gunshot").GetComponent<ParticleSystem>();        //get particle system
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))                //if player clicks, fire bullet
        {
            firebullet();
        }
        if (Input.GetAxis("Fire1") != 0)
        {
            if (RT_used == false) firebullet();
            RT_used = true;
        }
        if (Input.GetAxis("Fire1") == 0) RT_used = false;
    }

    private void firebullet()
    {
        GameObject currentbullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;     //make instance of the bullet object
        currentbullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);                                                
        currentbullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);                                  //move bullet with force
        myaudio.Play();                                                                                                     //play audio source when fired
        gunshot.Play();                                                                                                     //play particle system effect when fired
        Destroy(currentbullet, destroyTime);                                                                                //destroy bullet after desired time
    }
}
