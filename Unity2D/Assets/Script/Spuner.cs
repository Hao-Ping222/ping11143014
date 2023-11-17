using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spuner : MonoBehaviour
{
    public List<GameObject>platforms= new List<GameObject>();
    public float spwanTime;
    private float countTime;
    private Vector3 spwanPosition;


    // Update is called once per frame
    void Update()
    {
        SpwanPlatform();
    }
    public void SpwanPlatform() {
        countTime += Time.deltaTime;
        spwanPosition=transform.position;
        spwanPosition.x = Random.Range(-3.3f, 3.3f);

        if (countTime >= spwanTime) { 
            CreatePlatform();
            countTime = 0;  
        }
    }
    public void CreatePlatform() {
        int index = Random.Range(0, platforms.Count);
        int spikeNum = 0;
        if (index == 4) { spikeNum++; }
        if (spikeNum > 1) { spikeNum = 0;
            countTime = spwanTime;
            return;
        }
        Instantiate(platforms[index],spwanPosition,Quaternion.identity);
        GameObject newPlatform= Instantiate(platforms[index], spwanPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
