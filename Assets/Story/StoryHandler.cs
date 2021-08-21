using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResetLevel {
    Start,
    KelseyReldret,
    HenryJinzandi,
    SusanaTevzenguve,
    ElissaMai,
    LancelotMoonglade,
    JusticeVavred,
    WibaTobolbelze,
    RadclyffeOdegoba,
    DevannaStibetvuri,
    JannisGelmodunte,
    RolloRondubroi
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
