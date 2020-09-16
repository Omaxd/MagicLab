using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public IContainer Container;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Container = GetComponentInParent<IContainer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FinishMission()
    {
        List<Element> l = Container.GetElements().ToList();
        List<Element> l2 = GameManager.Missions[GameManager.CurrentMission].NeededElements();

        if (l.Count() == l2.Count())
            if (l[0].ElementNumber == l2[0].ElementNumber)
                gameManager.FinishMission();
            else
                gameManager.MissionFailed();
        else
            gameManager.MissionFailed();
    }


    private void OnMouseDown()
    {
        FinishMission();
    }
}
