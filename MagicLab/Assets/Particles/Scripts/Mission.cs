using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    List<Element> RequiredElements;

    public Mission(Element[] elements)
    {
        RequiredElements = new List<Element>();
        RequiredElements.AddRange(elements);
    }

    public List<Element> NeededElements()
    {
        return RequiredElements;
    }


}
