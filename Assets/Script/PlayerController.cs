using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject healthText;
    public Animator playeranim;
    public float speed = 5f;
    public float rotateSpeed = 5f;
    public float damageRate = 5.0f;
    public float health = 100.0f;
    bool ismove = true;
   
   

    
    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
        healthText.GetComponent<Text>().text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W) && ismove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playeranim.SetBool("IsWalkBool", true);
        }
        else if (Input.GetKey(KeyCode.S) && ismove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
             playeranim.SetBool("IsWalkBool", true);
        }
         if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
         {
             playeranim.SetBool("IsWalkBool", false);
         }
         
        if (Input.GetKey(KeyCode.A) && ismove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0,-90, 0);
            playeranim.SetBool("IsWalkBool", true);
        }
        else if (Input.GetKey(KeyCode.D) && ismove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playeranim.SetBool("IsWalkBool", true);
        }
       
         if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
         {
             playeranim.SetBool("IsWalkBool", false);
       
         }
         if(Input.GetKeyDown(KeyCode.Space))
        {
            playeranim.SetTrigger("AttackTrigger");
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            if (health >= 0)
            {

                health -= damageRate * Time.deltaTime;
                healthText.GetComponent<Text>().text = "Health: " + health;
                
            }
            else
            {
                healthText.GetComponent<Text>().text = "Health:" + 0;
            }
            if (health <= 0)
            {
                ismove = false;
                if(health<=0)
                {
                    playeranim.SetTrigger("DeadTrigger");
                }
            }


        }

    }
   
}
