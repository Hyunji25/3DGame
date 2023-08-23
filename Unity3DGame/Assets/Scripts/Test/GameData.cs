using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static GameData Instance = null;

    public static GameData GetInstance()
    {
        if (Instance == null)
            Instance = new GameData();
        return Instance;
    }

    // 순찰 구간, 클리어 할 때마다 증가
    public int PatrolWayPoint = 4; // 4-9-

    public int LockDoor = 0; // 잠긴 문, 0-잠김, 1-1F, 2-2F, 3-3F
}
