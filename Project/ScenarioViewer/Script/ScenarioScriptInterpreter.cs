using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class ScenarioScriptInterpreter
{
    int pointer = 0;
    public bool IsEnd { get; private set; } = false;
    string[] scripts;
    public UnityEvent<string> WriteMainText { get; private set; } = new UnityEvent<string>();
    public UnityEvent<int> ChangeMainTextFontSize { get; private set; } = new UnityEvent<int>();
    public UnityEvent<float, float, float, float> ChangeMainTextFontColor { get; private set; } = new UnityEvent<float, float, float, float>();
    public UnityEvent<string> ChangeCharacterName { get; private set; } = new UnityEvent<string>();
    public UnityEvent<int> ChangeFace { get; private set; } = new UnityEvent<int>();
    public UnityEvent<string, int, Vector2> CreateFigure { get; private set; } = new UnityEvent<string, int, Vector2>();
    public UnityEvent<string, Vector2, float> MoveFigure { get; private set; } = new UnityEvent<string, Vector2, float>();
    public UnityEvent DeleteFace { get; private set; } = new UnityEvent();
    public UnityEvent<string> DeleteFigure { get; private set; } = new UnityEvent<string>();
    public UnityEvent<string, float, float> FadeFigure { get; private set; } = new UnityEvent<string, float, float>();
    public UnityEvent<string, bool> SetFlag { get; private set; } = new UnityEvent<string, bool>();
    public UnityEvent<float> Wait { get; private set; } = new UnityEvent<float>();
    public UnityEvent<int> PlayBGM { get; private set; } = new UnityEvent<int>();
    public UnityEvent<int, bool> PlaySE { get; private set; } = new UnityEvent<int, bool>();
    public UnityEvent<int> RewardMoney { get; private set; } = new UnityEvent<int>();
    public UnityEvent<MagicType> RewardMagicType { get; } = new UnityEvent<MagicType>();
    public UnityEvent<PowerUp> RewardPowerUp { get; } = new UnityEvent<PowerUp>();
    public UnityEvent EndScenarioView { get; } = new UnityEvent();
    public UnityEvent<int> BeginScenarioView { get; } = new UnityEvent<int>();

    public ScenarioScriptInterpreter(string script)
    {
        scripts = script.Split('\n').Select(x => x.Trim()).ToArray();
        IsEnd = false;
        pointer = 0;
    }


    public void MoveNext()
    {
        pointer++;
        if(pointer == scripts.Length)
        {
            IsEnd = true;
        }
    }

    public void Excecute()
    {
        string order = scripts[pointer];
        if(order.StartsWith("<") && order.EndsWith(">"))
        {
            if (order.StartsWith("<Text"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                if (header.Contains("size="))
                {
                    int sizeIndex = header.IndexOf("size=");
                    int firstIndex = sizeIndex + 6;
                    int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    string sizeString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    int size = int.Parse(sizeString);
                    ChangeMainTextFontSize.Invoke(size);
                }
                if (header.Contains("color="))
                {
                    int colorindex = header.IndexOf("color=");
                    int firstIndex = colorindex + 7;
                    int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    string colorString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    float[] RGBA = colorString.Split(',').Select(x => float.Parse(x)).ToArray();
                    ChangeMainTextFontColor.Invoke(RGBA[0], RGBA[1], RGBA[2], RGBA[3]);
                }
            }
            if (order.StartsWith("<CharaName"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("name=");
                int firstIndex = nameIndex + 6;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string nameString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                ChangeCharacterName.Invoke(nameString);
            }
            if (order.StartsWith("<ChangeFace"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("source=");
                int firstIndex = nameIndex + "source".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int source = int.Parse(sourceString);
                ChangeFace.Invoke(source);
            }
            if (order.StartsWith("<CreateFigure"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                
                int sizeIndex = header.IndexOf("id=");
                int firstIndex = sizeIndex + "id".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string id = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                
                int sourceindex = header.IndexOf("source=");
                firstIndex = sourceindex + "source".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceNumber = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int source = int.Parse(sourceNumber);

                int positionIndex = header.IndexOf("position=");
                firstIndex = positionIndex + "position".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string positionString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int[] position = positionString.Split(',').Select(x => int.Parse(x)).ToArray();

                CreateFigure.Invoke(id, source, new Vector2(position[0], position[1]));
            }
            if (order.StartsWith("<MoveFigure"))
            {

                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);

                int sizeIndex = header.IndexOf("id=");
                int firstIndex = sizeIndex + "id".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string id = header.Substring(firstIndex, lastIndex - firstIndex + 1);

                int sourceindex = header.IndexOf("duration=");
                firstIndex = sourceindex + "duration".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string durationString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                float duration = float.Parse(durationString);

                int positionIndex = header.IndexOf("destination=");
                firstIndex = positionIndex + "destination".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string positionString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int[] position = positionString.Split(',').Select(x => int.Parse(x)).ToArray();

                MoveFigure.Invoke(id, new Vector2(position[0], position[1]), duration);
            }
            if (order.StartsWith("<DeleteFace>"))
            {
                DeleteFace.Invoke();
            }
            if (order.StartsWith("<DeleteFigure"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("id=");
                int firstIndex = nameIndex + "id".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string id = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                DeleteFigure.Invoke(id);
            }
            if (order.StartsWith("<FadeFigure"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("id=");
                int firstIndex = nameIndex + "id".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string id = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                
                int sourceindex = header.IndexOf("duration=");
                firstIndex = sourceindex + "duration".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string durationString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                float duration = float.Parse(durationString);
                sourceindex = header.IndexOf("alpha=");
                firstIndex = sourceindex + "alpha".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string alphaString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                float alpha = float.Parse(alphaString);

                FadeFigure.Invoke(id, alpha, duration);
            }
            if (order.StartsWith("<SetFlag"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("name=");
                int firstIndex = nameIndex + "name".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string name = header.Substring(firstIndex, lastIndex - firstIndex + 1);

                int sourceindex = header.IndexOf("value=");
                firstIndex = sourceindex + "value".Length + 2;
                lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string durationString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                bool value = bool.Parse(durationString);
                

                SetFlag.Invoke(name, value);
            }
            if (order.StartsWith("<Wait"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("duration=");
                int firstIndex = nameIndex + "duration".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                float source = float.Parse(sourceString);
                Wait.Invoke(source);
            }
            if (order.StartsWith("<BGM"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("source=");
                int firstIndex = nameIndex + "source".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int source = int.Parse(sourceString);
                PlayBGM.Invoke(source);
            }
            if (order.StartsWith("<SE"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("source=");
                int firstIndex = nameIndex + "source".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int source = int.Parse(sourceString);
                bool isWait = false;
                if (header.Contains("IsWait"))
                {
                    nameIndex = header.IndexOf("isWait=");
                    firstIndex = nameIndex + "isWait".Length + 2;
                    lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    isWait = bool.Parse(sourceString);
                }
                PlaySE.Invoke(source, isWait);
            }
            if (order.StartsWith("<Reward"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                if (header.Contains("MagicType"))
                {
                    int nameIndex = header.IndexOf("MagicType=");
                    int firstIndex = nameIndex + "MagicType".Length + 2;
                    int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    var card = Resources.Load<MagicType>($"Project/MagicTypeCards/{sourceString}");
                    RewardMagicType.Invoke(card);
                }
                if (header.Contains("PowerUp"))
                {
                    int nameIndex = header.IndexOf("PowerUp=");
                    int firstIndex = nameIndex + "PowerUp".Length + 2;
                    int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    var card = Resources.Load<PowerUp>($"Project/PowerUpCards/{sourceString}");
                    RewardPowerUp.Invoke(card);
                }
                if (header.Contains("money"))
                {
                    int nameIndex = header.IndexOf("money=");
                    int firstIndex = nameIndex + "money".Length + 2;
                    int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                    string moneyString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                    int money = int.Parse(moneyString);
                    RewardMoney.Invoke(money);
                }
            }
            if (order.Contains("<End>"))
            {
                EndScenarioView.Invoke();
            }
            if (order.Contains("<Begin"))
            {
                int endIndex = order.IndexOf(">");
                string header = order.Substring(0, endIndex + 1);
                int nameIndex = header.IndexOf("id=");
                int firstIndex = nameIndex + "id".Length + 2;
                int lastIndex = header.IndexOf(startIndex: firstIndex, value: "'") - 1;
                string sourceString = header.Substring(firstIndex, lastIndex - firstIndex + 1);
                int id = int.Parse(sourceString);
                BeginScenarioView.Invoke(id);
            }
        }
        else
        {
            // É^ÉOÇ™ë∂ç›ÇµÇ»Ç¢ÇÃÇ≈íPèÉÇ»ï∂éöóÒï`âÊ
            WriteMainText.Invoke(order);
        }
    }
}
