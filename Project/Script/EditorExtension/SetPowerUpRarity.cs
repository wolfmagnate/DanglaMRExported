#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetPowerUpRarity
{
    public static void Create()
    {

        Rarity Rarity_rare = AssetDatabase.LoadAssetAtPath<Rarity>("Assets/Resources/Project/Rarity/Rare.asset");
        Rarity Rarity_common = AssetDatabase.LoadAssetAtPath<Rarity>("Assets/Resources/Project/Rarity/Common.asset");
        Rarity Rarity_uncommon = AssetDatabase.LoadAssetAtPath<Rarity>("Assets/Resources/Project/Rarity/Uncommon.asset");
        CardPack rare = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack1.asset");
        CardPack common = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack2.asset");
        CardPack uncommon = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack3.asset");

        foreach(PowerUp rareCard in rare.PowerUpContents)
        {
            rareCard.Rarity = Rarity_rare;
            EditorUtility.SetDirty(rareCard);
        }
        foreach (PowerUp commonCard in common.PowerUpContents)
        {
            commonCard.Rarity = Rarity_common;
            EditorUtility.SetDirty(commonCard);
        }
        foreach (PowerUp uncommonCard in uncommon.PowerUpContents)
        {
            uncommonCard.Rarity = Rarity_uncommon;
            EditorUtility.SetDirty(uncommonCard);
        }
        foreach(MagicType rareCard in rare.MagicTypeContents)
        {
            rareCard.Rarity = Rarity_rare;
            EditorUtility.SetDirty(rareCard);
        }
        foreach (MagicType commonCard in common.MagicTypeContents)
        {
            commonCard.Rarity = Rarity_common;
            EditorUtility.SetDirty(commonCard);
        }
        foreach (MagicType uncommonCard in uncommon.MagicTypeContents)
        {
            uncommonCard.Rarity = Rarity_uncommon;
            EditorUtility.SetDirty(uncommonCard);
        }

        // 保存
        AssetDatabase.SaveAssets();
        // エディタを最新の状態にする
        AssetDatabase.Refresh();
    }
}
#endif