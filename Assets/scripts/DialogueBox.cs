using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] Text dialogue;

    public static DialogueBox Instance;
    private int dialogue_index = -1;
    List<string> dialogue_lines = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowText(List<string> lines)
    {
        dialogue_lines = lines;
        dialogue_index = -1;
        if (dialogue_lines.Count > 0)
        {
            Show();
            NextLine();
        }
    }

    public void NextLine()
    {
        dialogue_index++;

        // Dialogue lines are over
        if(dialogue_lines.Count <= dialogue_index)
        {
            Hide();
            dialogue_index = -1;
        }
        else
        {
            dialogue.text = dialogue_lines[dialogue_index];
        }
    }

    private void Show()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
    }

    private void Hide()
    {
        gameObject.GetComponent<Canvas>().enabled = false;

    }
}
