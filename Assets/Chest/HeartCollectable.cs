using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
    public AudioClip heartPop;

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "diver") {
            AudioSource.PlayClipAtPoint(
                heartPop,
                GetComponent<Transform>().position,
                1f
              );
            GameObject player = collider.gameObject;
            DiverScript playerScript = player.GetComponent<DiverScript>();
            playerScript.HeartCollectable();
            Destroy(gameObject);
        }
    }
}
