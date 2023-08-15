using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> EnvironmentList;
    public GameObject EnvironmentPrefab;
    public GameObject EndGamePanel;

    public static int BestScore;
    [HideInInspector]
    public int Score;
    void Start()
    {
        HeroController.SpawnEnvironment += SpawnEnvironment;
        HeroController.EndGame += EndGame;
    }

    private void SpawnEnvironment()
    {
        GameObject prefab = Instantiate(EnvironmentPrefab);
        GameObject lastEnvironment = EnvironmentList.Last();
        prefab.transform.position = new Vector3(lastEnvironment.transform.position.x, 
                                                lastEnvironment.transform.position.y, 
                                                lastEnvironment.transform.position.z + 33);
        EnvironmentList.Add(prefab);
        if (EnvironmentList.Count >= 3)
        {
            Destroy(EnvironmentList[0]);
            EnvironmentList.RemoveAt(0);
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        EndGamePanel.SetActive(true);
    }
    private void OnDisable()
    {
        HeroController.SpawnEnvironment -= SpawnEnvironment;
        HeroController.EndGame -= EndGame;
    }
}
