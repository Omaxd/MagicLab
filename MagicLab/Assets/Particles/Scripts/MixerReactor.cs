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

        List<Element> newElements = new List<Element>();
        foreach (Element e in Elements)
        {
            HashNumber += (int)e.ElementNumber;
        }

        if (HashNumber != 0)
        {
            Element el = new Element(Enum.GetName(typeof(ElementType), HashNumber));
            newElements.Add(el);
        }

        return newElements;
    }
}