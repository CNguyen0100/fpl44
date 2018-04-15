﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesScript : MonoBehaviour {
    [SerializeField] private GameObject[] Damages;
    public GameObject[] equipLocation;

    public void setDamage(int level)
    {
        //print(transform + " is level" + level);

        //if no damage set
        if(Damages.Length == 0)
        {
            Debug.LogError(transform.parent + "/" + transform + " doesn't have damages set");
            return;
        }
        print(transform + "has loc length = " + equipLocation.Length);
        //if no equip location;
        if (equipLocation == null || equipLocation.Length == 0)
        {
            //print(transform.parent.name+" Replace " + gameObject + " with " + Damages[level - 1]);
            UtilityFunctions.replaceObject(gameObject, Damages[level - 1]);
        }
        else
        {
            int numberOfDamages = Random.Range(1, equipLocation.Length);
            for(int i=0; i< numberOfDamages; i++)
            {
                print("replace " + equipLocation[i] + "------" + Damages[level - 1]);
                UtilityFunctions.replaceObject(equipLocation[i], Damages[level - 1]);
            }

            Data equipData = transform.GetComponent<Data>();
            if (equipData == null)
            {
                Debug.LogError(transform.parent + "/" + transform.name + " should have Datascript");
                equipData = gameObject.AddComponent<Data>();
            }
            else
            {
                equipData.level = level;
            }
        }

    }
}
