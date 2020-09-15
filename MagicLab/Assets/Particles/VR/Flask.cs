using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour , IContainers
{
    public void Rotate(Vector3 q)
    {
        gameObject.transform.Rotate(q);
    }

    public void Transform(Vector3 v)
    {
        gameObject.transform.position += v; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(new Vector3(0,0,0.5f));
    }

}
