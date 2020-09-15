using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reactor : MonoBehaviour
{
    public abstract IEnumerable<Element> Reaction(IEnumerable<Element> elements);
}