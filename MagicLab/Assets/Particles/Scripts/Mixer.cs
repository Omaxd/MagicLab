using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Mixer : MonoBehaviour, IContainer
{

    public GameObject Tank;

    public List<Collider> Elements;

    public GameObject ElementPrefab;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Elements = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = 
            Physics.OverlapBox(Tank.transform.position, Tank.transform.lossyScale / 2,
            Quaternion.identity, layerMask);

        Elements = hitColliders.ToList();
    }





    public void Reaction()
    {
        IEnumerable<Element> El = new List<Element>();
        El = from E in Elements select E.GetComponent<Element>();
        El = El.ToList();

        List <Element> El2 = new List<Element>(El);

        El = MixingFormulas.Mix(El, this);

        if (El.Count() == El2.Count())
            return;
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
        foreach (Element E in elements)
        {
            GameObject g = ElementPrefab;


            g.GetComponent<Element>().Name = E.Name;
            g.GetComponent<Element>().ElementNumber = E.ElementNumber;

            g.GetComponent<Renderer>().material = GameManager.Materials[E.ElementNumber];


            Instantiate(g, Tank.transform.position, new Quaternion());

        }
    }


    public ContainerType TypeOfContainer()
    {
        return ContainerType.Mixer;
    }

    public Element[] GetElements()
    {
        IEnumerable<Element> El = new List<Element>();
        El = from E in Elements select E.GetComponent<Element>();
        return El.ToArray();
    }
}


