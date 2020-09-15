using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class MixingFormulas : MonoBehaviour
{



    public static List<Element> Mix(IEnumerable<Element> Elements, IContainer Container)
    {
        List<Element> newElements = new List<Element>();

        switch(Container.TypeOfContainer())
        {
            case ContainerType.Distiller:
                DistillerReactor D = new DistillerReactor();
                newElements = D.Reaction(Elements).ToList();
                break;

            case ContainerType.Mixer:
                MixerReactor M = new MixerReactor();
                newElements= M.Reaction(Elements).ToList();
                break;

            default:
                break;

        }

        return newElements;

    }


}
