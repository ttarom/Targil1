using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float Speed;
    public int Strikes;
    public int UpdateStrike;
    private Vector3 Start1;
    public int Bonus;
    public GameObject MyCanvas;
    public GameObject Points;
    public GameObject Hits;
    public GameObject Bullet;
    public Transform Player;
    public float BSpeed;
   



    // Use this for initialization - called once in the beggining
    void Start ()
    {
        UpdateStrike = Strikes; // null the strikes
        Start1 = transform.position; // go back to the start
        Speed = 5;
        BSpeed = 25;
       
    }
	
	// Update is called once per frame
	void Update () {

        //always move forward - delete if unwanted
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PewPew();
        }

    }

    public void OnTriggerEnter(Collider other) // Other is a variant
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("BOOM");

            UpdateStrike = UpdateStrike - 1;
                        
            if (UpdateStrike <= 0)
            {
                Debug.Log(" GAME OVER ");
                                
                Debug.Log(" Restart Game ");

                MyCanvas.SetActive(true);
                Speed = 0;
            
            }
        }
        if (other.tag == "Pickup")

        {
            Bonus = Bonus + 1;

            

            Destroy(other.gameObject); //terminate the other object that is taged (only the specific collid) gemeObject = all objects in the game
            
            


           // Debug.Log("Bonus:"+ Bonus );
                               
        }
         
        
    }

    public void RestartGame()

    {
        transform.position = Start1;
        UpdateStrike = Strikes;
        Speed = 5;
        MyCanvas.SetActive(false);
    }

    private void PewPew()
    {
       
                
        
        Instantiate(Bullet, Player.position, Player.rotation);
        Debug.Log("fire");

       
    }
   
}


    

