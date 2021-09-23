using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public void menuSelect()
    {
        menu.SetActive(true);
    }

    public void closeMenu()
    {
        menu.SetActive(false);
    }
}
