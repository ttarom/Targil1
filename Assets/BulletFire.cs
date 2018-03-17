using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletFire : MonoBehaviour
{

    public float TimeEnd;
    private float FirstTime;
    public float Bspeed;
    

    // Use this for initialization
    void Start()
    {
        FirstTime = Time.time;
        Bspeed = 30;


    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * Bspeed);

        if ((Time.time - FirstTime) > 2)
        {
            Destroy(this.gameObject);
        }



    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
            Debug.Log("hit");
        }

    }
}
     