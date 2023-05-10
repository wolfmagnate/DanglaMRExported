using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    [SerializeField]
    private List<Text> blocks;

    private void Start()
    {
        atCharacters = new List<int>(blocks.Count);
        for (int i = 0; i < atCharacters.Capacity; i++) {
            atCharacters.Add(0);
        }

        enabled = false;
    }

    [SerializeField]
    public int characterPerFrame;
    [SerializeField]
    public List<string> fullTexts;
    [SerializeField]
    public List<string> fixedTexts;

    private List<int> atCharacters;

    private void Update()
    {
        for (int block = 0; block < blocks.Count; block++) {
            for (int i = 0; i < characterPerFrame; i++) {
                if (atCharacters[block] < fullTexts[block].Length) {
                    blocks[block].text += fullTexts[block][atCharacters[block]];
                    atCharacters[block]++;
                }
            }
        }
    }

    public void SetFullTextsFromBlocks() {
        for (int i = 0; i < blocks.Count; i++) {
            fullTexts[i] = blocks[i].text;
        }
    }

    public void StartTyping() {
        atCharacters.ForEach(ac => ac = 0);
        blocks.ForEach(b => b.text = fixedTexts[blocks.IndexOf(b)]);

        enabled = true;
    }

    public void StopTyping() {
        atCharacters.ForEach(ac => ac = 0);
        blocks.ForEach(b => b.text = "");
        
        enabled = false;
    }
}