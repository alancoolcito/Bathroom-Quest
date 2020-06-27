using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject objects;
    [SerializeField] bool toggle = false;
    [SerializeField] Button button;

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void DisableObjects()
    {
        if (!toggle)
        {
            objects.SetActive(false);
            toggle = true;

            button.image.color = Color.green;
        }
        else
        {
            objects.SetActive(true);
            toggle = false;

            button.image.color = Color.red;
        }
    }

}
