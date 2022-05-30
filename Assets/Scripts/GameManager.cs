using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _locationNameLabel;
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _storyLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Image _locationBackground;

    [Header("Initial Setup")]
    [SerializeField] private Step _startStep;

    [Header("External Components")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private int _menuSceneIndex;
    [SerializeField] private string _endGameSceneName;

    private Step _currentStep;
    private bool _isLose;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _locationBackground.color = Color.white;
        _menuButton.onClick.AddListener(MenuButtonClicked);
        SetCurrentStep(_startStep);
    }

    private void Update()
    {
        GameOverCheck();
        
        int choiceIndex = GetPressedButtonIndex();

        if (!IsIndexValid(choiceIndex))
            return;

        SetCurrentStep(choiceIndex);
    }

    #endregion


    #region Private methods

    private void GameOverCheck()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;

        if (_currentStep.Steps.Length == 0)
        {
            DataHolder.EndGameSprite = _currentStep.LocationBackground;
            DataHolder.EndGameText = !_isLose ? "You win" : "You lose";
            _sceneLoader.LoadScene(_endGameSceneName);
        }
    }

    private void MenuButtonClicked()
    {
        _sceneLoader.LoadScene(_menuSceneIndex);
    }

    private bool IsIndexValid(int choiceIndex) =>
        choiceIndex >= 0;

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Steps.Length <= choiceIndex)
            return;

        Step nextStep = _currentStep.Steps[choiceIndex];
        SetCurrentStep(nextStep);
    }

    private int GetPressedButtonIndex()
    {
        int pressedButtonIndex = NumButtonHelper.GetPressedButtonIndex();
        return pressedButtonIndex - 1;
    }

    private void SetCurrentStep(Step step)
    {
        if (step == null)
            return;

        _currentStep = step;

        _locationNameLabel.text = step.LocationName;
        _headerLabel.text = step.HeaderText;
        _storyLabel.text = step.StoryText;
        _choicesLabel.text = step.ChoicesText;
        _isLose = step._isLose;
        _locationBackground.sprite = step.LocationBackground;
    }

    #endregion
}