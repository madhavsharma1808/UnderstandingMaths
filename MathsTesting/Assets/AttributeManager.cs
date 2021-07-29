using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    public Text attributeDisplay;
    int attribute = 0;
    public static int MAGIC = 1;
    public static int FLY = 2;
    public static int INTELLIGENCE=4;
    public static int INVISIBLE = 8;
    public static int CHARISMA = 16;
   
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "magic")
            attribute |= MAGIC;
        if (collision.gameObject.tag == "charisma")
            attribute |= CHARISMA;
        if (collision.gameObject.tag == "fly")
            attribute |= FLY;
        if (collision.gameObject.tag == "intelligence")
            attribute |= INTELLIGENCE;
        if (collision.gameObject.tag == "invisible")
            attribute |= INVISIBLE;
        if (collision.gameObject.tag == "addmore")
            attribute |= INTELLIGENCE | MAGIC |CHARISMA;
        if (collision.gameObject.tag == "subtractmore")
            attribute &= ~(INTELLIGENCE | MAGIC );
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attribute, 2).PadLeft(8, '0');
    }
       
}
