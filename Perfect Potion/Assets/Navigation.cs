using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenPotionShopScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenFarmScene()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenCraftScene()
    {
        SceneManager.LoadScene(3);
    }

    public void OpenInventoryScene()
    {
        SceneManager.LoadScene(4);
    }
    public void OpenTradeScene()
    {
        SceneManager.LoadScene(5);
    }
    public void OpenRecipeScene()
    {
        SceneManager.LoadScene(6);
    }

}
