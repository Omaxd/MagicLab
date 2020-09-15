using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Distiller : MonoBehaviour, IContainer
{

    public GameObject Tank;

    public List<Collider> Elements;

    public GameObject ElementPrefab;

   



    // Start is called before the first frame update
    void Start()
    {
        Elements = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapBox(Tank.transform.position, Tank.transform.localScale / 2, Quaternion.identity);

        Elements = hitColliders.ToList();
    }





    public void Reaction()
    {
        IEnumerable<Element> El = new List<Element>();
        El = from E in Elements select E.GetComponent<Element>();
        El = El.ToList();


        El = MixingFormulas.Mix(El, this);

        DestroyElements();
        CreateElements(El);

    }

    public void DestroyElements()
    {
        foreach (Collider C in Elements)
            Destroy(C.gameObject);
    }

    public void CreateElements(IEnumerable<Element> elements)
    {
        
        foreach(Element E in elements)
        {
            GameObject g = ElementPrefab;

            
            g.GetComponent<Element>().Name = E.Name;
            g.GetComponent<Element>().ElementNumber = E.ElementNumber;

            g.GetComponent<Renderer>().material = GameManager.Materials[E.ElementNumber];


            Instantiate(g, gameObject.transform.position, new Quaternion());            
            
        }
    }


    public ContainerType TypeOfContainer()
    {
        return ContainerType.Distiller;
    }

    public Element[] GetElements()
    {
        IEnumerable<Element> El = new List<Element>();
        El = from E in Elements select E.GetComponent<Element>();
        return El.ToArray();

        
    }
}


