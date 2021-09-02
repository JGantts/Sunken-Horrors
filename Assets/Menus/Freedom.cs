using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freedom : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeSinceLevelLoad > 3f) {
              SceneManager.LoadScene("Start");
        }
    }
}
