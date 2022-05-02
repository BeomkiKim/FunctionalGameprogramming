using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlockCreator : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    int blockCount = 0;

    public void createBlock(Vector3 blockPosition)
    {
        int nextBlockType = blockCount % blockPrefabs.Length;

        GameObject go = GameObject.Instantiate(blockPrefabs[nextBlockType]) as GameObject;
        go.transform.position = blockPosition;
        blockCount++;
    }
}
