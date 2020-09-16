using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerReactor : Reactor
{

    public MixerReactor()
    {

    }

    public override IEnumerable<Element> Reaction(IEnumerable<Element> Elements)
    {
        int HashNumber = 0;
        Element el;
        List<Element> newElements = new List<Element>();
        foreach (Element e in Elements)
        {
            HashNumber += (int)e.ElementNumber;
        }

        if (HashNumber != 0)
        {
            el = new Element(Enum.GetName(typeof(ElementType), HashNumber));
            newElements.Add(el);
        }

        if (newElements[0].Name == null)
            return Elements;
        GameManager.ElementsInGame.AddRange(newElements);
        return newElements;
    }
}