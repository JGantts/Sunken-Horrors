using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueBackground : MonoBehaviour
{
    public Transform diver;
    public float surfaceHeight;
    public float surfaceBreakingHeight = 242.3889f;
    public float multiplier;
    public List<LevelAndPage> pageObjects;

    Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        Vector2 pagePosition = pageObjects.First(levelAndPage => levelAndPage.level == StoryHandler.The.level).page.GetComponent<Transform>().position;
        diver.position = new Vector2(pagePosition.x + 3, pagePosition.y);
    }

    void FixedUpdate()
    {

        if (diver.position.y >= surfaceHeight) {
            myTransform.localPosition = new Vector3(
            0,
            -multiplier * (diver.position.y - surfaceHeight),
            myTransform.localPosition.z);
            if (diver.position.y >= surfaceBreakingHeight) {
                SceneManager.LoadScene("Freedom");
            }
        } else {
            myTransform.localPosition = new Vector3(0, 0, myTransform.localPosition.z);
        }
    }
}
