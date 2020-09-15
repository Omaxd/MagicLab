using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainer
{
    void DestroyElements();
    void CreateElements(IEnumerable<Element> elements);
    void Reaction();
    ContainerType TypeOfContainer();
    Element[] GetElements();

}

public enum ContainerType
{
    Mixer,
    Distiller
}