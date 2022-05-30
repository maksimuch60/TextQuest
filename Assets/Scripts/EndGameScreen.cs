using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _sceneName;
    [SerializeField] private TextMeshProUGUI _endGameText;
    [SerializeField] private Image _endGameImage;

    private void Start()
    {
        _endGameImage.color = Color.white;
        _endGameImage.sprite = DataHolder.EndGameSprite;
        _endGameText.text = DataHolder.EndGameText;
        _menuButton.onClick.AddListener(MenuButtonClicked);
    }

    private void MenuButtonClicked()
    {
        _sceneLoader.LoadScene(_sceneName);
    }
}