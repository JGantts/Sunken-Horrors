using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResetLevel {
    Start,
    One,
    Two,
    Three
}

[Serializable]
public class LevelAndPage {
    public ResetLevel level;
    public PageObject page;
}

[Serializable]
public class LevelAndSprite {
    public ResetLevel level;
    public Sprite sprite;
}

public class StoryHandler {
    public static StoryHandler The = new StoryHandler();

    public ResetLevel level = ResetLevel.Start;
    public bool displayingStory = false;
    public float displayedStoryTime = 0f;
}
