using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
              SceneManager.LoadScene("Diver");
        }
    }
}
