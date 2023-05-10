using UnityEngine;
using UnityEngine.UI;

public class TypingProduction : MonoBehaviour {
    [SerializeField]
    private int characterPerFrame;
    
    private Text text;
    private string fullText;
    private int atCharacter;
    
    private void Awake() {
        text = GetComponent<Text>();
        fullText = text.text;

        text.text = "";
        atCharacter = 0;
    }

    private void Update() {
        for (int i = 0; i < characterPerFrame; i++) {
            if (atCharacter < fullText.Length) {
                text.text += fullText[atCharacter];
                atCharacter++;
            }
        }
    }

    private void OnEnable() {
        text.text = "";
        atCharacter = 0;
    }

    private void OnDisable() {
        text.text = "";
        atCharacter = 0;
    }
}