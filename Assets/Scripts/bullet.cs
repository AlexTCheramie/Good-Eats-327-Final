using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class bullet : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletForce = 100.0f;
    public float destroyTime = 3.0f;
    AudioSource myaudio;
    private ParticleSystem gunshot;
    private bool RT_used = false;

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
        gunshot = GameObject.Find("gunshot").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
        GameObject currentbullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
        currentbullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        currentbullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
        myaudio.Play();
        gunshot.Play();
        Destroy(currentbullet, destroyTime);
    }
}
