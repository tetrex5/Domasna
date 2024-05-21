using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public float gazeTime = 3f; // Времето што треба да се гледа копчето
    private float timer;
    private bool isGazing;

    private void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            Debug.Log("Gazing: " + timer); // Додавање на дебаг лог
            if (timer >= gazeTime)
            {
                OnGazeComplete();
                timer = 0f;
                isGazing = false;
            }
        }
        else if (timer > 0f)
        {
            timer = 0f;
        }
    }

    public void OnPointerEnter()
    {
        isGazing = true;
        Debug.Log("Started gazing at " + gameObject.name); // Додавање на дебаг лог
    }

    public void OnPointerExit()
    {
        isGazing = false;
        timer = 0f;
        Debug.Log("Stopped gazing at " + gameObject.name); // Додавање на дебаг лог
    }



    private void OnGazeComplete()
    {

        SceneManager.LoadScene(0);
    }
}
