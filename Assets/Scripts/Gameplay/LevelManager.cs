using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> terrains;
    [SerializeField] TextMeshProUGUI level;
    int levelNumber = 0;
    GameObject actualTerrain;
    // Start is called before the first frame update
    void Start()
    {
        level.text = "LEVEL: " + levelNumber;
        RestartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        if (actualTerrain != null)
            Destroy(actualTerrain);
        actualTerrain=Instantiate(terrains[Random.Range(0, terrains.Count)]);
        levelNumber++;
        level.text = "LEVEL: " + levelNumber;
    }
}
