using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIsPaused : MonoBehaviour
{
    public GameObject BoardUI;

    void Awake()
    {
        BoardUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            BoardUI.SetActive(false);
        }
        else
        {
            BoardUI.SetActive(true);
        }
            
    }
}
