using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlock
{
    //블록의 종류(나중에 장애물 여기에 추가)
    public enum TYPE
    {
        NONE = -1,
        FLOOR = 0,
        HOLE,
        NUM,
    }
}
public class UpMapCreator : MonoBehaviour
{
    public static float BLOCKWIDTH = 1.0f;
    public static float BLOCKHEIGHT = 0.2f;
    public static int BLOCKNUMINSCREEN = 36;
    UpLevelControl uplevelControl = null;
    struct FloorBlock
    {
        public bool isCreated;
        public Vector3 position;
    }

    FloorBlock lastBlock;
    public Transform playerTransform;
    //PlayerControl player = null;
    UpBlockCreator blockCreator;
    public TextAsset UpLevelDataText = null;
    GameRoot gameRoot = null;

    private void Start()
    {
        blockCreator = gameObject.GetComponent<UpBlockCreator>();
        gameRoot = gameObject.GetComponent<GameRoot>();
        uplevelControl = new UpLevelControl();
        uplevelControl.initialize();
        //player.upLevelControl = uplevelControl;
        uplevelControl.loadUpLevelData(UpLevelDataText);
    }

    void createFloorBlock()
    {
        Vector3 blockPosition;
        if (!lastBlock.isCreated)
        {
            blockPosition = playerTransform.transform.position;
            blockPosition.x -= BLOCKWIDTH * ((float)BLOCKNUMINSCREEN / 2.0f);
            //blockPosition.y = 9.0f;
        }
        else
        {
            blockPosition = lastBlock.position;
        }
        blockPosition.x += BLOCKWIDTH;

        //blockCreator.createBlock(blockPosition);
        uplevelControl.update(gameRoot.getPlayTime());
        blockPosition.y = uplevelControl.currentBlock.height * BLOCKHEIGHT;
        UpLevelControl.CreationInfo current = uplevelControl.currentBlock;

        if (current.blockType == UpBlock.TYPE.FLOOR)
        {
            blockCreator.createBlock(blockPosition);
        }
        lastBlock.position = blockPosition;
        lastBlock.isCreated = true;
    }

    public bool isDelete(GameObject blockObject)
    {
        bool ret = false;
        float leftLimit = playerTransform.transform.position.x - BLOCKWIDTH * ((float)BLOCKNUMINSCREEN / 2.0f);

        if (blockObject.transform.position.x < leftLimit)
        {
            ret = true;
        }
        return (ret);
    }

    private void Update()
    {
        float blockGenerateX = playerTransform.transform.position.x;

        blockGenerateX += BLOCKWIDTH * ((float)BLOCKNUMINSCREEN + 1) / 2.0f;

        while (lastBlock.position.x < blockGenerateX)
        {
            createFloorBlock();
        }
    }
}
