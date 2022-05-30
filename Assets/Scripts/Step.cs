using UnityEngine;
using UnityEngine.UI;

public class Step : MonoBehaviour
{
    #region Varialbes

    public Sprite LocationBackground;
    public string LocationName;
    public string HeaderText;

    [TextArea(4, 6)]
    public string StoryText;

    [TextArea(4, 6)]
    public string ChoicesText;

    public Step[] Steps;
    public bool _isLose;

    #endregion
}