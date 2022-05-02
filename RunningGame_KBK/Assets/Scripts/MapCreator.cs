using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public static float BLOCKWIDTH = 1.0f;
    public static float BLOCKHEIGHT = 0.2f;
    public static int BLOCKNUMINSCREEN = 24;

    struct FloorBlock
    {
        public bool isCreated;
        public Vector3 position;
    }

    FloorBlock lastBlock;
    public Transform player;
    BlockCreator blockCreator;

    private void Start()
    {
        blockCreator = gameObject.GetComponent<BlockCreator>();
    }

    void createFloorBlock()
    {
        Vector3 blockPosition;
        if(!lastBlock.isCreated)
        {
            blockPosition = player.transform.position;
            blockPosition.x -= BLOCKWIDTH * ((float)BLOCKNUMINSCREEN / 2.0f);
            blockPosition.y = -1.5f;
        }
        else
        {
            blockPosition = lastBlock.position;
        }
        blockPosition.x += BLOCKWIDTH;

        blockCreator.createBlock(blockPosition);
        lastBlock.position = blockPosition;
        lastBlock.isCreated = true;
    }

    public bool isDelete(GameObject blockObject)
    {
        bool ret = false;
        float leftLimit = player.transform.position.x - BLOCKWIDTH * ((float)BLOCKNUMINSCREEN / 2.0f);

        if(blockObject.transform.position.x<leftLimit)
        {
            ret = true;
        }
        return (ret);
    }

    private void Update()
    {
        float blockGenerateX = player.transform.position.x;

        blockGenerateX += BLOCKWIDTH * ((float)BLOCKNUMINSCREEN + 1) / 2.0f;

        while(lastBlock.position.x<blockGenerateX)
        {
            createFloorBlock();
        }
    }
}
