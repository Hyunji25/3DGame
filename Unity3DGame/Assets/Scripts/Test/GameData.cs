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

    // ���� ����, Ŭ���� �� ������ ����
    public int PatrolWayPoint = 4; // 4-9-

    public int LockDoor = 0; // ��� ��, 0-���, 1-1F, 2-2F, 3-3F
}
