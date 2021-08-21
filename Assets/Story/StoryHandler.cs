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

public class StoryHandler {
    public static StoryHandler The = new StoryHandler();

    public ResetLevel level = ResetLevel.Start;
}
