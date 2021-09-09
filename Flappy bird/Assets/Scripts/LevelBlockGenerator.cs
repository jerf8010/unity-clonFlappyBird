using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour
{
    public LevelBlock levelBlock;
    public LevelBlock lastLevelBlock;
    public LevelBlock currentLevelBlock;

    public PipeMoves blockPipe;
    public float blockGenerationTime  = 2;
    // Start is called before the first frame update
    void Start()
    {
        AddNewBlock();

        InvokeRepeating("GenerateNewBlockPipe", 0, blockGenerationTime);
    }

    // Update is called once per frame
    void Update()
    {
        float xcam = Camera.main.transform.position.x;
        float xold = lastLevelBlock.exitPoint.position.x;

        if (xcam > xold + lastLevelBlock.width/2)
        {
            RemoveOldBlock();
        }
    }

    public void AddNewBlock()
    {
        LevelBlock block = (LevelBlock)Instantiate(levelBlock);
        block.transform.SetParent(this.transform, false);

        Vector3 blockPosition = Vector3.zero;

        blockPosition = new Vector3( lastLevelBlock.exitPoint.position.x + block.width / 2, 
                                      lastLevelBlock.exitPoint.position.y,
                                      lastLevelBlock.exitPoint.position.z);

        block.transform.position = blockPosition;

        currentLevelBlock = block;
    }
    public void RemoveOldBlock()
    {
        Destroy(lastLevelBlock.gameObject);
        lastLevelBlock = currentLevelBlock;
        AddNewBlock();
    }

    public void GenerateNewBlockPipe()
    {
        float distanceToGenerate = levelBlock.width / 3;
        float randomY = Random.Range(0, 8);
        float randomV = Random.Range(4, 10);

        PipeMoves pipeBlock = (PipeMoves)Instantiate(blockPipe);

        Vector3 pipePosition = Vector3.zero;

        pipePosition = new Vector3(Camera.main.transform.position.x + distanceToGenerate, randomY, 0);

        pipeBlock.speed = randomV;

        pipeBlock.transform.position = pipePosition;
    }


}
