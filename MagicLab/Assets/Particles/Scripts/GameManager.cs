using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static Mission[] Missions;
    public static int CurrentMission = 0;

    public static Dictionary<ElementType, Material> Materials;
    // Start is called before the first frame update
    public void Start()
    {
        Materials = new Dictionary<ElementType, Material>();


        object[] mats = Resources.LoadAll("Materials/Materials");


        foreach (object mat in mats)
        {
            if (Enum.IsDefined(typeof(ElementType), ((Material)mat).name))
            {
                Material m = new Material ((Material)(mat));
                object obj = Enum.Parse(typeof(ElementType), m.name);
                ElementType t = (ElementType)obj;
                
                Materials.Add(t, m);
                

            }


        }
        Debug.Log("leo");


        Missions = new Mission[] { new Mission(new Element[] { new Element(ElementType.H2O) }) };
        


    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void FinishMission()
    {
        Debug.Log("You win");
    }

    public static void MissionFailed()
    {
        Debug.Log("You lose");
    }


}


public enum ElementType
{
    H = 1,
    O = 8,
    H2O = 100,

}
