using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Asteriod asteriodPrefab;
    public int asteriodCount = 0;
    private int level = 0;
    // Update is called once per frame
    void Update()
    {
        if (asteriodCount == 0)
        {
            level++;
            int numberOfAsteriods = 2 + (2 * level);
            for (int i = 0; i < numberOfAsteriods; i++)
            {
                spawnAsteriod();
            }
        }
    }

    void spawnAsteriod()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

        int edge = Random.Range(0, 4);
        switch (edge)
        {
            case 0:
                viewportSpawnPosition = new Vector2(offset, 0);
                break;
            case 1:
                viewportSpawnPosition = new Vector2(1, offset);
                break;
            case 2:
                viewportSpawnPosition = new Vector2(offset, 1);
                break;
            case 3:
                viewportSpawnPosition = new Vector2(0, offset);
                break;
        }
        Vector2 worldspawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteriod asteriod = Instantiate(asteriodPrefab, worldspawnPosition, Quaternion.identity);
        asteriod.gameManager = this;
    }

    public void GameOver()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        Debug.Log("Game Over");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }

}
