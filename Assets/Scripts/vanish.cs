using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanish : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Vanish", lifetime);
    }

    void Vanish()
    {
        Destroy(gameObject);
    }

 
}
