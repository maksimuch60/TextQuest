using UnityEngine;

public class Step : MonoBehaviour
{
    public string HeaderText;

    [TextArea(4, 6)]
    public string StoryText;
    
    [TextArea(4, 6)]
    public string ChoicesText;

    public Step[] Steps;
}