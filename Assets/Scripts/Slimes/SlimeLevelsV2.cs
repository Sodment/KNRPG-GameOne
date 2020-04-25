﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLevelsV2 : MonoBehaviour
{
   // List<Crystal> Crystals = new List<Crystal>(); Z tego by była tylko długość... dokładnie taka sama jak z colors
    List<Color> Colors = new List<Color>();

    Color[] CrystalColor = new Color[4];

    public float Attack = 10;
    public float AttackSpeed = 0.3F;
    public float Health = 50;
    public float MovmentSpeed = 0.3F;

    int[] Typ = new int[4];

    public void Start()
    {
        GameObject Crystal = Resources.Load("Crystals/EarthCrystalV2") as GameObject;
        CrystalColor[0] = Crystal.GetComponent<Renderer>().sharedMaterial.color;
        Crystal = Resources.Load("Crystals/FireCrystalV2") as GameObject;
        CrystalColor[1] = Crystal.GetComponent<Renderer>().sharedMaterial.color;
        Crystal = Resources.Load("Crystals/WaterCrystalV2") as GameObject;
        CrystalColor[2] = Crystal.GetComponent<Renderer>().sharedMaterial.color;
        Crystal = Resources.Load("Crystals/WindCrystalV2") as GameObject;
        CrystalColor[3] = Crystal.GetComponent<Renderer>().sharedMaterial.color;
    }

    public void AddCrystal(Crystal crystal)
    {
        Typ[crystal.Type]++;
        Attack += crystal.AttackBonus;
        AttackSpeed += crystal.AttackSpeedBonus;
        Health += crystal.HealthBonus;
        MovmentSpeed += crystal.MovmentSpeedBonus;

        Colors.Add(CrystalColor[crystal.Type]);

        Vector3 ColorVec = Vector3.zero;
        foreach(Color k in Colors)
        {
            ColorVec += new Vector3(k.r, k.g, k.b);
        }
        ColorVec.Normalize();
        ColorVec /= Mathf.Max(ColorVec.x, ColorVec.y, ColorVec.z);
        transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(ColorVec.x, ColorVec.y, ColorVec.z,0.5f);

        GetQuirck();
    }

    public int[] Crystals()
    {
        List<int> CrystalList = new List<int>();
        
        for(int i=0; i<4; i++)
        {
            for(int type=0; type<Typ[i]; type++)
            {
                CrystalList.Add(i);
            }
        }
        return CrystalList.ToArray();
    }

    void GetQuirck()
    {
        if (Colors.Count == 3)
        {
            if (Typ[0] == 3)
            {
                gameObject.AddComponent<Shild>();
            }
            else if (Typ[1] == 3)
            {
                gameObject.AddComponent<FireAttackV2>();
            }
            else if (Typ[2] == 3)
            {
                gameObject.AddComponent<FireImmunity>();
            }
            else if (Typ[3] == 3)
            {
                gameObject.AddComponent<Atletyka>();
            }
            else
            {
                int rand = Random.Range(0, 4);
                switch (rand)
                {
                    case 0: { gameObject.AddComponent<Shild>(); break; }
                    case 1: { gameObject.AddComponent<FireAttackV2>(); break; }
                    case 2: { gameObject.AddComponent<FireImmunity>(); break; }
                    case 3: { gameObject.AddComponent<Atletyka>(); break; }
                }
            }
        }
        else if (Colors.Count == 6)
        {
            if (Typ[0] == 6)
            {
                gameObject.AddComponent<ShildLvl2>();
            }
            else if (Typ[1] == 6)
            {
                gameObject.AddComponent<FireAttackLvl2>();
            }
            else if (Typ[2] == 6)
            {
                gameObject.AddComponent<Healer>();
            }
            else if (Typ[3] == 6)
            {
                gameObject.AddComponent<SliWondoAttack1>();
                gameObject.AddComponent<SliWondoDefense1>();
            }
            else
            {
                Debug.Log("Quirck \"Deszcze niespokojnie\" jeszcze nieopracwany");
                //gameObject.AddComponent<>(); //TO DO
            }
        }
        if (Colors.Count == 9)
        {
            if (Typ[0] == 9)
            {
                gameObject.AddComponent<ShildLvl3>();
            }
            else if (Typ[1] == 9)
            {
                gameObject.AddComponent<FireAttackLvl3>();
            }
            else if (Typ[2] == 9)
            {
                gameObject.AddComponent<HealerLvl3>();
                gameObject.AddComponent<FireImmunityLvl3>();
            }
            else if (Typ[3] == 9)
            {
                gameObject.AddComponent<SliWondoAttackLvl3>();
                gameObject.AddComponent<SliWondoDefenseLvl3>();
            }
            else
            {
                Debug.Log("Quirck \"Al-Slimone\" jeszcze nieopracwany");
                //gameObject.AddComponent<>(); //TO DO
            }
        }
    }
}
