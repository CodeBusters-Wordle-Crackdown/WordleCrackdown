using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class CS_Achievement : MonoBehaviour
{

    [Header("Animation")]
    public TextMeshProUGUI achievementUI;
    private Vector3 achievementDefaultPos;
    [SerializeField]
    [Tooltip("The max height the achievement get animation will travel when it disappears")]
    private int achievementAnimationMaxHeight;
    [SerializeField]
    [Tooltip("How fast the animation will play until it reaches its max height")]
    private float achievementFloatSpeed;

    [Header("Achievements")]
    [Tooltip("Correctly guess a word in under 30 seconds")]
    public bool speedDemon;
    [Tooltip("Correctly guess a word with less than 10 seconds remaining")]
    public bool clutch;
    [Tooltip("Correctly guess a word on the final attempt")]
    public bool oneMoreTry;
    [Tooltip("Get three new correct letters in one guess")]
    public bool threeBirds;

    public void UnlockAchievement(string name)
    {
        switch (name)
        {
            case "Speed Demon":
                if (speedDemon)
                    return;
                speedDemon = true; break;
            case "Clutch":
                if (clutch)
                    return;
                clutch = true; break;
            case "One More Try":
                if (oneMoreTry)
                    return;
                oneMoreTry = true; break;
            case "Three Birds":
                if (threeBirds) 
                    return;
                threeBirds = true; break;
        }
        achievementUI.gameObject.SetActive(true);
        achievementUI.text = "Achievement Unlocked!\n" + name;
    }

    private void Start()
    {
        achievementDefaultPos = achievementUI.rectTransform.position;
    }

    private void Update()
    {
        // Play achievement animation when gameobject is active
        if (achievementUI.gameObject.activeSelf)
        {
            achievementUI.fontMaterial.SetColor("_FaceColor", new Color(1, 1, 1, (achievementDefaultPos.y + achievementAnimationMaxHeight - achievementUI.rectTransform.position.y) / achievementAnimationMaxHeight));
            achievementUI.rectTransform.position = new Vector3(achievementUI.rectTransform.position.x, achievementUI.rectTransform.position.y + Time.deltaTime * achievementFloatSpeed, achievementUI.rectTransform.position.z);
        }

        // If achievement gameobject has reached its max height, turn it off and reset its position
        if(achievementUI.rectTransform.position.y >= achievementDefaultPos.y + achievementAnimationMaxHeight)
        {
            achievementUI.gameObject.SetActive(false);
        }
    }


    private void OnDisable()
    {
        achievementUI.rectTransform.position = achievementDefaultPos;
    }
}
