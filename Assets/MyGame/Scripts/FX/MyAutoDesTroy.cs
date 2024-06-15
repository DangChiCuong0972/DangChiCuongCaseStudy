using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyScript/MyAutoDesTroy")]
public class MyAutoDesTroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

   
}
