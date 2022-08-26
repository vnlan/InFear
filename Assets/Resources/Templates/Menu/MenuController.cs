using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    //public GameObject levelMenu;
    void Start()
    {
        //levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    
    void Update()
    {
        
    }

    public void showLevelMenu()
    {
        
        //levelMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void hiddenLevelMenu()
    {
        //evelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
