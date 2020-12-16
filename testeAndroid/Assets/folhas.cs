using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folhas : MonoBehaviour
{

    public Vector3 posi;
    // Start is called before the first frame update
    void Awake()
    {
        posi = gameObject.transform.position;

    }

    void OnEnable(){
        gameObject.transform.position = posi;
        
    }
}