using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class FlagManager
{
    static FlagManager()
    {
        if (PlayerPrefs.HasKey(FlagSaveID))
        {
            string loadText = PlayerPrefs.GetString(FlagSaveID);
            flagManager = JsonUtility.FromJson<FlagManager>(loadText);
        }
        else
        {
            flagManager = new FlagManager();
            flagManager.IDs = new string[200];
            flagManager.Values = new bool[200];
            Save();
        }
        if (PlayerPrefs.HasKey(ScenarioFlagSaveID))
        {
            scenario = PlayerPrefs.GetInt(ScenarioFlagSaveID);
        }
        else
        {
            scenario = 0;
            SaveScenarioFlag();
        }
        if (PlayerPrefs.HasKey(StageFlagSaveID))
        {
            stage = PlayerPrefs.GetInt(StageFlagSaveID);
        }
        else
        {
            stage = 1;
            SaveStageFlag();
        }
        for(int i = 0;i < 15; i++)
        {
            if(HasFlag($"__{i + 1}__scenario__viewed__")) { continue; }
            SetFlag($"__{i + 1}__scenario__viewed__", false);
        }
    }
    static FlagManager flagManager;
    [SerializeField]
    string[] IDs;
    [SerializeField]
    bool[] Values;

    static int scenario;
    static int stage;
    static readonly string FlagSaveID = "__flag__manager__save__id__";
    static readonly string ScenarioFlagSaveID = "__flag__manager__save__id__scenario";
    static readonly string StageFlagSaveID = "__flag__manager__save__id__stage";

    public static void Save()
    {
        string saveText = JsonUtility.ToJson(flagManager);
        PlayerPrefs.SetString(FlagSaveID, saveText);
    }

    public static void SaveStageFlag()
    {
        PlayerPrefs.SetInt(StageFlagSaveID, stage);
    }

    public static void SaveScenarioFlag()
    {
        PlayerPrefs.SetInt(ScenarioFlagSaveID, scenario);
    }

    public static void SetFlag(string flagName, bool val)
    {
        if (string.IsNullOrEmpty(flagName)) { throw new InvalidOperationException(); }
        int vacantIndex = 0;
        for(int i = 0;i < 200; i++)
        {
            if(string.IsNullOrEmpty(flagManager.IDs[i]) || flagManager.IDs[i] == flagName)
            {
                vacantIndex = i;
                break;
            }
        }
        flagManager.IDs[vacantIndex] = flagName;
        flagManager.Values[vacantIndex] = val;
    }

    public static bool GetFlag(string flagName)
    {
        if (string.IsNullOrEmpty(flagName)) { throw new InvalidOperationException(); }
        int index = Array.IndexOf(flagManager.IDs, flagName);
        return flagManager.Values[index];
    }

    public static bool HasFlag(string flagName)
    {
        if (string.IsNullOrEmpty(flagName)) { throw new InvalidOperationException(); }
        return flagManager.IDs.Contains(flagName);
    }

    public static int ScenarioFlag()
    {
        return scenario;
    }

    public static int StageFlag()
    {
        return stage;
    }

    public static void ChangeStageFlag(int stageLevel)
    {
        if(stageLevel < 0 || stageLevel > 15) { return; }
        stage = stageLevel;
    }

    public static void ChangeScenarioFlag(int scenarioLevel)
    {
        if(scenarioLevel < 0 || scenarioLevel > 15) { return; }
        scenario = scenarioLevel;
    }
}
