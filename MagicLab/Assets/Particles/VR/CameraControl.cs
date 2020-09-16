using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_MovementSpeed;
    public float m_CameraRotationSpeed;

    public bool inPlace = false;

    public Element MarkedE;

    Camera m_Cam;
    Rigidbody m_Rig;

    // Start is called before the first frame update
    void Start()
    {


        m_Cam = GetComponentInChildren<Camera>();
        m_Rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {

        if (inPlace)
        {

            float a;
            float b;
            float c;

            a = Input.GetAxis("Horizontal");
            b = -Input.GetAxis("Vertical");
            c = Input.GetAxis("Up");



            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = m_Cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        Element e = hit.collider.gameObject.GetComponent<Element>();
                        if (e != null)
                        {
                            if (MarkedE == e)
                            {
                                e.UnMarked();
                                MarkedE = null;
                            }
                            else
                            {
                                if (MarkedE == null)
                                {
                                    e.Marked();
                                    MarkedE = e;
                                }
                                else
                                {
                                    MarkedE.UnMarked();
                                    MarkedE = e;
                                    e.Marked();
                                }
                            }
                        }
                        else
                        {
                            if (MarkedE != null)
                            {
                                MarkedE.UnMarked();
                                MarkedE = null;
                            }
                        }
                    }

                }



            }
            if (MarkedE != null)
            {
                MarkedE.Translate(new Vector3(-a, -c, b) * 0.1f);
                return;
            }


            m_Cam.transform.Rotate(b, 0, 0, Space.Self);
            m_Cam.transform.Rotate(0, a, 0, Space.Self);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_Cam.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (MarkedE != null)
                MarkedE.UnMarked();
            inPlace = !inPlace;
        }


    }

    void FixedUpdate()
    {
        if (!inPlace)
        {
            float x;
            float y;

            y = Input.GetAxis("Forward");
            x = Input.GetAxis("Side");

            Vector3 zz = transform.rotation * Vector3.forward * y * m_MovementSpeed;

            m_Rig.velocity = zz;

            transform.Rotate(0, x * 5, 0);
        }
        else
            m_Rig.velocity = Vector3.zero;

    }
}
