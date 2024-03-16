/**
 * Author: Hudson Green
 * Contributors: N/A
 * Date Created: 2024-03-16
 * Description: To be placed on textbox that will display round counter
**/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WaveCounter : MonoBehaviour
{

    [SerializeField] public GameObject enemySpawnerObject = null;

    [SerializeField] public string roundPrefix = "Round: ";
    [SerializeField] public string roundSuffix = "";

    void Update()
    {
        // Guard against missing enemy spawner game object
        if (enemySpawnerObject == null) return;
        // Guard against missing EnemySpawner component on enemySpawnerObject
        if (enemySpawnerObject.GetComponent<EnemySpawner>() == null) return;

        // Get the text component
        TextMeshProUGUI txtBox = GetComponent<TextMeshProUGUI>();

        // Get the current round off the EnemySpawner object
        int round = enemySpawnerObject.GetComponent<EnemySpawner>().waveCount;

        txtBox.text = roundPrefix + round + roundSuffix;
    }

}
