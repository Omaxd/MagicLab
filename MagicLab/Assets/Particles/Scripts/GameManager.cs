using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static List<Mission> Missions = new List<Mission>();
    public static int CurrentMission = -1;


    public static List<Element> ElementsInGame = new List<Element>();

    public static Dictionary<ElementType, Material> Materials;

    public static List<string> MissionsString = new List<string>();

    public Text BoardText;
    public Desk PlayerDesk;


    public GameObject Dobrze;
    public GameObject Zle;



    // Start is called before the first frame update
    public void Start()
    {
        MissionsString.Add("Lekcja 1 \n" + "Stworz czasteczke wody");
        MissionsString.Add("Lekcja 2 \n" + "Stworz kwas siarkowy ");
        MissionsString.Add("Lekcja 3 \n" + "Stworz amoniak");



        Materials = new Dictionary<ElementType, Material>();


        object[] mats = Resources.LoadAll("Materials/Materials");


        foreach (object mat in mats)
        {
            if (Enum.IsDefined(typeof(ElementType), ((Material)mat).name))
            {
                Material m = new Material((Material)(mat));
                object obj = Enum.Parse(typeof(ElementType), m.name);
                ElementType t = (ElementType)obj;

                Materials.Add(t, m);


            }


        }




        Mission a = new Mission(new List<Element> { new Element(ElementType.H2O) }, new List<Element> { new Element(ElementType.H), new Element(ElementType.H), new Element(ElementType.O) });
        Mission b = new Mission(new List<Element> { new Element(ElementType.H2SO4) }, new List<Element> { new Element(ElementType.S),
            new Element(ElementType.H), new Element(ElementType.H), new Element(ElementType.O),
            new Element(ElementType.O),new Element(ElementType.O), new Element(ElementType.O) });
        Mission c = new Mission(new List<Element> { new Element(ElementType.H2SO4) }, new List<Element> { new Element(ElementType.S),
            new Element(ElementType.H), new Element(ElementType.H), new Element(ElementType.O),
            new Element(ElementType.O),new Element(ElementType.O), new Element(ElementType.O) });

        Missions.Add(a);
        Missions.Add(b);
        Missions.Add(c);


        newMission();

    }

    // Update is called once per frame
    void Update()
    {
        BoardText.text = MissionsString[CurrentMission];

    }

    public void FinishMission()
    {
        Instantiate(Dobrze);
        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Element"))          
                Destroy(G);
        newMission();
    }

    public void MissionFailed()
    {
        Instantiate(Zle);
    }

    public void newMission()
    {
        CurrentMission++;
        PlayerDesk.SpawnElements(Missions[CurrentMission].AvailableElements);
    }






}


public enum ElementType
{
    H = 1,
    O = 8,
    H2O = 10,
    H2SO4 = 50,
    S = 16,

}
