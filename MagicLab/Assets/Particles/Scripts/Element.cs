using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool m_Marked = false;

    public string Name;
    public ElementType ElementNumber;


    public Element(ElementType E)
    {                
        ElementNumber = E;
        Name = E.ToString();
    }

    public ElementType GetElementType()
    {
        return ElementNumber;
    }

    public void OnEnable()
    {
        if(Name == null)
        {
            Name = GetComponent<Material>().name;
            ElementNumber = (ElementType) Enum.Parse(typeof(ElementType), Name);
        }
    }

    public void Remove()
    {
        Destroy(this);
    }

    public void Marked()
    {
        m_Marked = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Clicked");
    }
    public void UnMarked()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        m_Marked = false;
        Debug.Log("UnClicked");
    }

    public void Translate(Vector3 transform)
    {
        gameObject.transform.Translate(transform);
    }

}
