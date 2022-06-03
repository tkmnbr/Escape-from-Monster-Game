using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpwaner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    [SerializeField]
    private Transform leftps, rightps;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonsters());
    }

    // Update is called once per frame
    IEnumerator spawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);


            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftps.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            if (randomSide == 1)
            {
                spawnedMonster.transform.position = rightps.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
