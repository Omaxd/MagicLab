using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mission
{
    List<Element> RequiredElements;
    List<Element> AvailableElements;
    public Mission(IEnumerable<Element> RElements, IEnumerable<Element> AElements)
    {
        RequiredElements = new List<Element>();
        RequiredElements.AddRange(RElements);
        
        AvailableElements = new List<Element>();
        AvailableElements.AddRange(AElements);
    }

    public List<Element> NeededElements()
    {
        return RequiredElements;
    }


}
