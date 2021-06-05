using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject WallBounceEffectobj;
    public GameObject DeadEffectObj;
    public GameObject CanvasSummary;

    Rigidbody2D rb;
    int JumpX = 7;
    int JumpY = 15;

    bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(JumpX, JumpY);
            }
            else {
                rb.velocity = new Vector2(-JumpX, JumpY);
            }
        }
           
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") {
            GameObject effectObj = Instantiate(WallBounceEffectobj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
        }
        if (other.gameObject.tag == "Triangle"  && isDead == false) {
            isDead = true;
            GameObject effectObj = Instantiate(DeadEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);

            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            gameObject.SetActive(false);
            
            CanvasSummary.SetActive(true);
            
        }
    }
}
