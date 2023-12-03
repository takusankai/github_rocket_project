using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    void Start()
    {   
        Invoke("Disappear", 0.7f);
    }

    void Update()
    {

    }
    void Disappear()
    {
        Destroy(this.gameObject);
    }
}
