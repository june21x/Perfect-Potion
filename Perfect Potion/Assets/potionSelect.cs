using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class potionSelect : MonoBehaviour
{
    private GameObject[] potionList;
    private int index;

    private void Start()
    {
        potionList = new GameObject[transform.childCount];
        foreach (Transform t in transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                potionList[i] = transform.GetChild(i).gameObject;
            }

            foreach (GameObject go in potionList)
                go.SetActive(false);

            if (potionList[0])
                potionList[0].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        //off current model
        potionList[index].SetActive(false);
        
      
        index--;
        if (index < 0)
            index = potionList.Length - 1;

        //on current model
        potionList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //off current model
        potionList[index].SetActive(false);


        index++;
        if (index == potionList.Length)
            index = 0;

        //on current model
        potionList[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
