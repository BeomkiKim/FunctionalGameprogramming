using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLevelData
{
    public struct Range
    {
        public int min;
        public int max;

    };
    public float endTime;
    public float playerSpeed;

    public Range floorCount;
    public Range holeCount;

    public DownLevelData()
    {
        endTime = 60f;
        playerSpeed = 3.0f;
        floorCount.min = 10;
        floorCount.max = 10;
        holeCount.min = 2;
        holeCount.max = 6;


    }
}
public class LevelControl : MonoBehaviour
{
    List<DownLevelData> levelDatas = new List<DownLevelData>();
    public struct CreationInfo
    {
        public Block.TYPE blockType;
        public int maxCount;
        public int height;
        public int currentCount;
    };
    public CreationInfo previousBlock;
    public CreationInfo currentBlock;
    public CreationInfo nextBlock;
    public int blockCount = 0;
    public int level = 0;

    public float getPlayerSpeed()
    {
        return (levelDatas[level].playerSpeed);
    }
    public void loadDownLevelData(TextAsset DownLevelDataText)
    {
        string levelTexts = DownLevelDataText.text;
        string[] lines = levelTexts.Split('\n');

        foreach(var line in lines)
        {
            if(line =="")
            {
                continue;
            };
            string[] words = line.Split();
            int n = 0;

            DownLevelData downLevelData = new DownLevelData();

            foreach(var word in words)
            {
                if(word.StartsWith("#"))
                {
                    break;
                }
                if(word =="")
                {
                    continue;
                }

                switch(n)
                {
                    case 0: downLevelData.endTime = float.Parse(word); break;
                    case 1: downLevelData.playerSpeed = float.Parse(word);break;
                    case 2: downLevelData.floorCount.min = int.Parse(word);break;
                    case 3: downLevelData.floorCount.max = int.Parse(word);break;
                    case 4: downLevelData.holeCount.min = int.Parse(word);break;
                    case 5: downLevelData.holeCount.max = int.Parse(word);break;
                }
                n++;
            }
            if (n >= 6)//6항목(이상)
            {
                levelDatas.Add(downLevelData);
            }
            else
            {
                if (n == 0) { }
                else
                {
                    Debug.LogError("[DownLevelData] Out of parameter.\n");
                }
            }
        }
        if(levelDatas.Count == 0)
        {
            levelDatas.Add(new DownLevelData());
        }
    }
    void clearNextBlock(ref CreationInfo block)
    {
        block.blockType = Block.TYPE.FLOOR;
        block.maxCount = 15;
        block.height = -30;
        block.currentCount = 0;
    }

    public void initialize()
    {
        blockCount = 0;

        clearNextBlock(ref previousBlock);
        clearNextBlock(ref currentBlock);
        clearNextBlock(ref nextBlock);
    }

    void updateLevel(ref CreationInfo current, CreationInfo previous, float passageTime)
    {
        float localTime = Mathf.Repeat(passageTime, levelDatas[levelDatas.Count - 1].endTime);

        int i;
        for(i = 0; i< levelDatas.Count -1; i++)
        {
            if(localTime <= levelDatas[i].endTime)
            {
                break;
            }
        }
        level = i;

        current.blockType = Block.TYPE.FLOOR;
        current.maxCount = 1;

        if(blockCount >= 10)
        {
            DownLevelData downLevelData;
            downLevelData = levelDatas[level];

            switch(previous.blockType)
            {
                case Block.TYPE.FLOOR:
                    current.blockType = Block.TYPE.HOLE;
                    current.maxCount = Random.Range(downLevelData.holeCount.min, downLevelData.holeCount.max);
                    current.height = previous.height;
                    break;
                case Block.TYPE.HOLE:
                    current.blockType = Block.TYPE.FLOOR;
                    current.maxCount = Random.Range(downLevelData.floorCount.min, downLevelData.floorCount.max);
                    break;

            }
        }
    }

    public void update(float passageTime)
    {
        currentBlock.currentCount++;

        if(currentBlock.currentCount >= currentBlock.maxCount)
        {
            previousBlock = currentBlock;
            currentBlock = nextBlock;

            clearNextBlock(ref nextBlock);
            updateLevel(ref nextBlock, currentBlock,passageTime);
        }
        blockCount++;
    }
}
