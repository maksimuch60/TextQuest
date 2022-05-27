using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _storyLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;

    [Header("Initial Setup")]
    [SerializeField] private Step _startStep;
    private void Start()
    {
        SetStep(_startStep);
    }

    private void SetStep(Step step)
    {
        _headerLabel.text = step.HeaderText;
        _storyLabel.text = step.StoryText;
        _choicesLabel.text = step.ChoicesText;
    }
}