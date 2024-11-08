using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public PlayerController player;
    [SerializeField] public PoolManager pool;

    void Awake()
    {
        instance = this;
    }
}
