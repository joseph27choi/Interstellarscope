using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCounter : MonoBehaviour
{
    [SerializeField] List<GameObject> boostIcons = new List<GameObject>();
    public void setBoosts(int num)
    {
        for (int i = 0; i < boostIcons.Count; i++)
        {
            boostIcons[i].SetActive(i < num);
        }
    }
}
