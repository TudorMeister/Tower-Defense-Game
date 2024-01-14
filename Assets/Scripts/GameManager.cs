using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public List<Enemy> enemiesList = new List<Enemy>();
    public List<GameObject> turretList = new List<GameObject>();
    public GameObject canvas;
    public GameObject win;
    public GameObject lose;
    public int targetWaves;
    public WaveSpawner waveSpawner;
    private bool reload = false;
    public GameObject enemyPrefab;
    public GameObject canonBallTurretPrefab;
    public GameObject freezeTurretPrefab;
    public GameObject machineGunTurretPrefab;
    public GameObject canonBallTurretPrefabUpgraded;
    public GameObject freezeTurretPrefabUpgraded;
    public GameObject machineGunTurretPrefabUpgraded;
    public List<WallNode> nodesList = new List<WallNode>();


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        nodesList = FindObjectsOfType<WallNode>().ToList<WallNode>();
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeSelf == true)
            {
                canvas.SetActive(false);
                Time.timeScale = 1.0f;
            } else
            {
                canvas.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        if (waveSpawner.GetWave() > targetWaves && !reload && !(lose.active == true))
        {
            win.SetActive(true);
            reload = true;
            string currentSceneName = SceneManager.GetActiveScene().name;
            Invoke("LoadNextLevel", 5.0f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            SaveFunction();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFunction();
        }

    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "LevelFinal_1") {
            SceneManager.LoadScene("LevelFinal_2");
        } else
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }


    public int GetWave()
    {
        return waveSpawner.GetWave();
    }
    

    public void SaveFunction()
    {
        SaveObject saveObject = new SaveObject
        {
            moneyAmount = BuildManager.instance.money,
            waveIndex = waveSpawner.GetWave(),
            health = FindObjectOfType<Target>().health,
            levelName = SceneManager.GetActiveScene().name,
        };

        foreach (Enemy enemy in enemiesList)
        {
            saveObject.enemiesPos.Add(enemy.transform.position);
        }

        foreach (GameObject turret in turretList)
        {
            saveObject.turretPos.Add(turret.transform.position);
            saveObject.turretType.Add(turret.GetComponent<BaseTurret>().type);
        }

        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/save.txt", json);

        
        Debug.Log(json);

    }


    public void LoadFunction()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            //Time.timeScale = 0.0f;
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            Debug.Log("Loaded: " + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            if (saveObject.levelName != SceneManager.GetActiveScene().name)
            {
                //Time.timeScale = 1.0f;
                Debug.Log("Not a save from this level");
                return;
            }

            BuildManager.instance.money = saveObject.moneyAmount;
            waveSpawner.SetWave(saveObject.waveIndex);
            FindObjectOfType<Target>().health = saveObject.health;

            foreach(Enemy enemy in enemiesList)
            {
                Destroy(enemy.gameObject);
            }

            enemiesList.Clear();

            foreach(GameObject turret in turretList)
            {
                Destroy(turret);
            }

            turretList.Clear();

            foreach(WallNode node in nodesList)
            {
                node._isOccupied = false;
            }



            foreach (Vector3 pos in saveObject.enemiesPos)
            {
                Instantiate(enemyPrefab, pos, Quaternion.identity);
            }
            int aux = 0;
            foreach (Vector3 pos in saveObject.turretPos)
            {
                if (saveObject.turretType[aux] == 1)
                {
                    Instantiate(canonBallTurretPrefab, pos, Quaternion.identity);
                }
                if (saveObject.turretType[aux] == 2)
                {
                    Instantiate(freezeTurretPrefab, pos, Quaternion.identity);
                }
                if (saveObject.turretType[aux] == 3)
                {
                    Instantiate(machineGunTurretPrefab, pos, Quaternion.identity);
                }
                if (saveObject.turretType[aux] == 4)
                {
                    Instantiate(canonBallTurretPrefabUpgraded, pos, Quaternion.identity);
                }
                if (saveObject.turretType[aux] == 5)
                {
                    Instantiate(freezeTurretPrefabUpgraded, pos, Quaternion.identity);
                }
                if (saveObject.turretType[aux] == 6)
                {
                    Instantiate(machineGunTurretPrefabUpgraded, pos, Quaternion.identity);
                }
                WallNode closestNode = null;
                float minDistance = 999999f;
                foreach (WallNode node in nodesList)
                {
                    if (Vector3.Distance(pos, node.transform.position) < minDistance)
                    {
                        closestNode = node;
                        minDistance = Vector3.Distance(pos, node.transform.position);
                    }
                }

                closestNode._isOccupied = true;


                aux++;
            }



            //Time.timeScale = 1.0f;
        }
        else
        {
            Debug.Log("No save");
        }
    }


    private class SaveObject
    {
        public int moneyAmount;
        public int waveIndex;
        public int health;
        public string levelName;
        public List<Vector3> enemiesPos = new List<Vector3>();
        public List<Vector3> turretPos = new List<Vector3>();
        public List<int> turretType = new List<int>();
    }


}
