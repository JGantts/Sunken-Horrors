using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageObject : MonoBehaviour
{
    public ResetLevel level;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "diver") {
            StoryHandler.The.level = level;
            SceneManager.LoadScene("Retry");
        }
    }
}
