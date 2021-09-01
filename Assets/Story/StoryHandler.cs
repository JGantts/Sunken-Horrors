using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResetLevel {
    Start,
    Schultz1,
    Chernenko1,
    Allison1,
    Sukitora1,
    Schultz2,
    Chernenko2,
    Allison2,
    Sukitora2,
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
