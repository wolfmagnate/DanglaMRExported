using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtil
{
    public static T GetRandomElement<T>(this T[] ary) => ary[Random.Range(0, ary.Length)];
}
