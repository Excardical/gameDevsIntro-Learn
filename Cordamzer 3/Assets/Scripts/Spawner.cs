using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;

    void Start() {
        StartCoroutine(spawnMonster());
    }

    IEnumerator spawnMonster() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if(randomSide == 0) {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<HarbingerOfDeathScript>().speed = Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-2.5f, 2.5f, 1f);
            } else {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<HarbingerOfDeathScript>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
            }
        }
    }

}
