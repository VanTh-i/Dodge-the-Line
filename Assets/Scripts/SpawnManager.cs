using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] linePrefabs;
    public GameObject arrowUp;
    public GameObject arrowDown;

    private float linePos = 9;

    Vector3 spawnPos;
    public bool turnPos;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        StartCoroutine(SpawnInterval());
    }
    IEnumerator SpawnInterval()
    {

        while (true)
        {
            arrowDown.gameObject.SetActive(true);
            arrowUp.gameObject.SetActive(false);

            yield return new WaitForSeconds(1f);

            for (int i = 0; i <= 10; i++)
            {
                turnPos = true;
                int randomLine = Random.Range(0, linePrefabs.Length);

                if (randomLine == 2)
                {
                    float greyRandomPosX = Random.Range(-1.5f, 1.5f);
                    spawnPos = new Vector3(greyRandomPosX, linePos, 0);
                }
                else
                {
                    spawnPos = new Vector3(0, linePos, 0);
                }

                yield return new WaitForSeconds(2f);

                Instantiate(linePrefabs[randomLine], spawnPos, linePrefabs[randomLine].transform.rotation);
            }

            arrowDown.gameObject.SetActive(false);
            arrowUp.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            for (int i = 0; i <= 10; i++)
            {
                turnPos = false;
                int randomLine = Random.Range(0, linePrefabs.Length);

                if (randomLine == 2)
                {
                    float greyRandomPosX = Random.Range(-1.5f, 1.5f);
                    spawnPos = new Vector3(greyRandomPosX, -linePos, 0);
                }
                else
                {
                    spawnPos = new Vector3(0, -linePos, 0);
                }

                yield return new WaitForSeconds(2f);

                Instantiate(linePrefabs[randomLine], spawnPos, linePrefabs[randomLine].transform.rotation);
            }      
            
        }
    }
}
