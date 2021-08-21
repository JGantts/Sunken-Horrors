using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageObject : MonoBehaviour
{
    public ResetLevel level;
    public Image paragraph;
    public List<LevelAndSprite> sprites;

    float m_lastActivationTime = 0f;

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.name == "diver" && (m_lastActivationTime + 4f) < Time.timeSinceLevelLoad) {
            Time.timeScale = 0;
            StoryHandler.The.level = level;

            paragraph.color = Color.white;
            paragraph.sprite = sprites.First(x => x.level == StoryHandler.The.level).sprite;

            StoryHandler.The.displayingStory = true;
            StoryHandler.The.displayedStoryTime = Time.realtimeSinceStartup;
            m_lastActivationTime = Time.timeSinceLevelLoad;
        }
    }
}
