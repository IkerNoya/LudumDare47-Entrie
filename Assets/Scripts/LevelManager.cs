﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] GameObject[] levels;

    [SerializeField] GameObject[] doors;

    GameManager gm;
    int actualLevel = 1;

    private void Start() {
        gm = GameManager.instanceGM;
       //for (int i = 0; i < doors.Length; i++)
       //    if (doors[i] != null)
       //        doors[i].SetActive(false);
       //
       //int doorToOpen = Random.Range(0, doors.Length);
       //if (doors[doorToOpen] != null)
       //    doors[doorToOpen].SetActive(true);
       //
        PlayerController.DoorEnter += ChangeLevel;

        for (int i = 0; i < levels.Length; i++)
            if (levels[i] != null)
                levels[i].SetActive(false);

        if (levels[actualLevel] != null) {
            levels[actualLevel].SetActive(true);
        }

        doors = GameObject.FindGameObjectsWithTag("Door");
        
    }
    private void OnDisable() {
        PlayerController.DoorEnter -= ChangeLevel;
    }
    private void Update()
    {
        CheckNextLevel();
    }
    public void CheckNextLevel()
    {
        if (gm != null)
        {
            if (gm.GetCurrentCountEnemy() <= 0 && gm.GetEnableCheckNextLevel())
            {
                ChangeLevel();
            }
        }
    }
    public void ChangeLevel() {
        actualLevel++;
        if (actualLevel > 3)
            actualLevel = 1;

        for (int i = 0; i < doors.Length; i++)
            if (doors[i] != null)
                doors[i].SetActive(false);

        if (doors.Length > 0)
            Array.Clear(doors, 0, doors.Length);

        for (int i = 0; i < levels.Length; i++)
            if (levels[i] != null)
                levels[i].SetActive(false);

        if (levels[actualLevel] != null)
            levels[actualLevel].SetActive(true);

        doors = GameObject.FindGameObjectsWithTag("Door");

        // int doorToOpen = Random.Range(0, doors.Length);
        // while (doors[doorToOpen] == door.gameObject)
        //     doorToOpen = Random.Range(0, doors.Length);
        //
        // if (doors[doorToOpen] != null)
        //     doors[doorToOpen].SetActive(true);

    }

    public int GetCurrentLevel()
    {
        return actualLevel;
    }

    public GameObject[] GetLevels()
    {
        return levels;
    }
}
