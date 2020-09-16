using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    public CameraControl cameraControl;
    public GameObject ElementPrefab;

    public GameObject Aura;
    public Transform DeskSpot;
    public Transform ElementSpawnSpot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cameraControl.inPlace = true;
        cameraControl.GetComponent<Transform>().rotation = new Quaternion(0,180,0,0);
        cameraControl.GetComponent<Transform>().position= DeskSpot.position;

        Destroy(Aura);
    }

    public void SpawnElements(List<Element> Elements)
    {
        
        for(int i = 0; i< Elements.Count; i++) 
        {
            Element E = Elements[i];
            GameObject g = ElementPrefab;
            GameManager.ElementsInGame.Add(E);

            g.GetComponent<Element>().Name = E.Name;
            g.GetComponent<Element>().ElementNumber = E.ElementNumber;

            g.GetComponent<Renderer>().material = GameManager.Materials[E.ElementNumber];

            
            Instantiate(g, ElementSpawnSpot.position + new Vector3(-i/4 * 0.1f,0,i%4 * 0.1f), new Quaternion());
            Instantiate(g, ElementSpawnSpot.position + new Vector3(-i / 4 * 0.1f - 0.2f, 0, i % 4 * 0.1f), new Quaternion());



        }



    }
}
