using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public List<Image> FlamesImages;

    public Button MoveLeftButton;
    public Button MoveRightButton;

    public HeroController Character;
    public GameController GameController;

    void Start()
    {
        HeroController.FlameChanged += UpdateScoreUI;

        UpdateScoreUI(0);

        MoveLeftButton.onClick.AddListener(() =>
        {
            if (Character.transform.position.x - 2 >= -2) StartCoroutine(MoveCharacter(-2));
        });

        MoveRightButton.onClick.AddListener(() =>
        {
            if (Character.transform.position.x + 2 <= 2) StartCoroutine(MoveCharacter(2));
        });
    }

    IEnumerator MoveCharacter(float xPos)
    {
        MoveLeftButton.interactable = false;
        MoveRightButton.interactable = false;
        short resXPos = (short)(Character.transform.position.x + xPos);
        while (Character.transform.position.x != resXPos)
        {
            Character.transform.position = Vector3.MoveTowards(Character.transform.position, new Vector3(resXPos, Character.transform.position.y, Character.transform.position.z), Time.deltaTime * 8);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        MoveLeftButton.interactable = true;
        MoveRightButton.interactable = true;
    }

    private void UpdateScoreUI(int score)
    {
        GameController.Score += score;
        ScoreText.text = $"Score:{GameController.Score}";

        for(int i = 0; i < FlamesImages.Count; i++)
        {
            if (i < Character.Flames) FlamesImages[i].color = Color.white;
            else FlamesImages[i].color = Color.black;
        }
    }

    private void OnDisable()
    {
        HeroController.FlameChanged -= UpdateScoreUI;
    }
}
