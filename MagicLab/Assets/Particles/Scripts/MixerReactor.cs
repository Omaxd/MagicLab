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
        List<Element> newElements = new List<Element>();
        //foreach (Element e in Elements)
        //{
        //    if (e.GetElementType() == ElementType.H2O)
        //    {
        //        newElements.Add(new Element(ElementType.H2O));
        //    }
        //}
        newElements.Add(new Element(ElementType.H2O));
        return newElements;
    }
}