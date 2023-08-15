using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    public HeroController CharacterController;
    public Button StartGameButton;
    void Start()
    {
        StartGameButton.onClick.AddListener(() =>
        {
            CharacterController.enabled = true;
            gameObject.SetActive(false);
        });
    }
}
