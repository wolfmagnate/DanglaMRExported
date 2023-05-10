using System.Collections;
using System.Collections.Generic;
using System;

public static class LoopUtil
{

    public static void Times(this int times, Action<int> action)
    {
        for (int i = 0; i < times; i++)
        {
            action(i);
        }
    }

    public static void Times(this int times, Action action)
    {
        for (int i = 0; i < times; i++)
        {
            action();
        }
    }

    public static void UpTo(this int from,int to, Action<int> action)
    {
        for(int i = from;i <= to; i++)
        {
            action(i);
        }
    }


    public static void DownTo(this int from, int to, Action<int> action)
    {
        for (int i = from; i >= to; i--)
        {
            action(i);
        }
    }

}
