using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLevelData
{
    public struct Range
    {
        public int min;
        public int max;

    };
    public float endTime;
    public Range floorCount;
    public Range holeCount;

    public UpLevelData()
    {
        endTime = 60f;
        floorCount.min = 10;
        floorCount.max = 10;
        holeCount.min = 2;
        holeCount.max = 6;
    }
}
public class UpLevelControl : MonoBehaviour
{
        List<UpLevelData> upLevelDatas = new List<UpLevelData>();

    public struct CreationInfo
    {
        public UpBlock.TYPE blockType;
        public int maxCount;
        public int height;
        public int currentCount;
    };
    public CreationInfo previousBlock;
    public CreationInfo currentBlock;
    public CreationInfo nextBlock;
    public int blockCount = 0;
    public int level = 0;

    public void loadUpLevelData(TextAsset UpLevelDataText)
    {
        string levelTexts = UpLevelDataText.text;
        string[] lines = levelTexts.Split('\n');

        foreach (var line in lines)
        {
            if (line == "")
            {
                continue;

            };
            string[] words = line.Split();
            int n = 0;

            UpLevelData upLevelData = new UpLevelData();

            foreach (var word in words)
            {
                if (word.StartsWith("#"))
                {
                    break;
                }
                if (word == "")
                {
                    continue;
                }

                switch (n)
                {
                    case 0: upLevelData.endTime = float.Parse(word); break;
                    case 1: upLevelData.floorCount.min = int.Parse(word); break;
                    case 2: upLevelData.floorCount.max = int.Parse(word); break;
                    case 3: upLevelData.holeCount.min = int.Parse(word); break;
                    case 4: upLevelData.holeCount.max = int.Parse(word); break;
                }
                n++;
            }
            if (n >= 5)//5항목(이상)
            {
                upLevelDatas.Add(upLevelData);
            }
            else
            {
                if (n == 0) { }
                else
                {
                    Debug.LogError("[UpLevelData] Out of parameter.\n");
                }
            }
        }
        if (upLevelDatas.Count == 0)
        {
            upLevelDatas.Add(new UpLevelData());
        }
    }
    void clearNextBlock(ref CreationInfo block)
    {
        block.blockType = UpBlock.TYPE.HOLE;
        block.maxCount = 15;
        block.height = 50;
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
        float localTime = Mathf.Repeat(passageTime, upLevelDatas[upLevelDatas.Count - 1].endTime);
        int i;
        for(i=0; i< upLevelDatas.Count-1;i++)
        {
            if(localTime<= upLevelDatas[i].endTime)
            {
                break;
            }
        }
        level = i;

        current.blockType = UpBlock.TYPE.FLOOR;
        current.maxCount = 1;

        if(blockCount >= 10)
        {
            UpLevelData upLevelData;
            upLevelData = upLevelDatas[level];

            switch (previous.blockType)
            {
                case UpBlock.TYPE.FLOOR:
                    current.blockType = UpBlock.TYPE.HOLE;
                    current.maxCount = Random.Range(upLevelData.holeCount.min, upLevelData.holeCount.max);
                    current.height = previous.height;
                    break;
                case UpBlock.TYPE.HOLE:
                    current.blockType = UpBlock.TYPE.FLOOR;
                    current.maxCount = Random.Range(upLevelData.floorCount.min, upLevelData.floorCount.max);
                    break;
            }

        }

    }

    public void update(float passageTime)
    {
        currentBlock.currentCount++;

        if (currentBlock.currentCount >= currentBlock.maxCount)
        {
            previousBlock = currentBlock;
            currentBlock = nextBlock;

            clearNextBlock(ref nextBlock);
            updateLevel(ref nextBlock, currentBlock, passageTime);
        }
        blockCount++;
    }
}
