using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMoreLess : MonoBehaviour
{
    private Image imageComponent;
    public GameObject moreNavigations;
    public Sprite more, less;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    public void ToggleMoreNavigation()
    {
        if (!moreNavigations.activeSelf)
        {
            moreNavigations.SetActive(true);
            imageComponent.sprite = less;
        }
        else
        {
            moreNavigations.SetActive(false);
            imageComponent.sprite = more;
        }


    }
}