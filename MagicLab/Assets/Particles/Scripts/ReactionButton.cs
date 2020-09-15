using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionButton : MonoBehaviour
{

    public IContainer Container;
    public Button Button;

    // Start is called before the first frame update
    void Start()
    {
        Container =  GetComponentInParent<IContainer>();
    }

    // Update is called once per frame
    void Update()
    {
       //Object[] obj =  Resources.FindObjectsOfTypeAll(typeof(Material));
    }

    void Reaction()
    {
        Container.Reaction();
    }

    void OnMouseDown()
    {
        Reaction();
    }
}
