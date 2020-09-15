using System.Collections.Generic;

public class DistillerReactor : Reactor
{
    public DistillerReactor()
    {

    }

    public override IEnumerable<Element> Reaction(IEnumerable<Element> Elements)
    {
        List<Element> newElements = new List<Element>();
        foreach(Element e in Elements)
        {
            if (e.GetElementType() == ElementType.H2O)
            {
                newElements.Add(new Element(ElementType.O));
                newElements.Add(new Element(ElementType.O));
                newElements.Add(new Element(ElementType.H));

            }
        }

        return newElements;
    }
}