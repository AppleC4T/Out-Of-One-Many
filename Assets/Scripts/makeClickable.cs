using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeClickable : MonoBehaviour
{
    public bool isClippingGround;
    public float defaultY;
    public bool isToFollow = true;

    // Start is called before the first frame update
    void Start()
    {
        
        defaultY = transform.position.y - 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isClippingGround == false && isToFollow == true)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, distance_to_screen)), 1f);
        }

        
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (transform.position.y >= defaultY)
            {
                isClippingGround = false;
            }
            else
            {
                isClippingGround = true;
            }
        }
    }

    void OnMouseUpAsButton()
    {
        isToFollow = !isToFollow;   
    }
}
