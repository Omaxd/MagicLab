using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mission
{
    public List<Element> RequiredElements;
    public List<Element> AvailableElements;
    


    public Mission(List<Element> RElements, List<Element> AElements)
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
