using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree: MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;

    [SerializeField] private int recursionDepht = 3;

    [Header("Root Lenght")]
    [SerializeField] private float rootLenght = 4.5f;
    
    private float currentLenght = -1;
    [SerializeField] private float reductionLenghtFactor = 0.2f;
    private int currentDepth = 0;
    private Queue<GameObject> frontier = new Queue<GameObject>();   

    private void Start()
    {
        currentLenght = rootLenght;
        GameObject root = Instantiate(branchPrefab,transform);       
        SetBranchLenght(root, currentLenght);

        frontier.Enqueue(root);
        ++currentDepth;
        GenerateTree();
    }

    #region Recursion Base
    // Recursi�n: Una funci�n que se llama a s� misma, es una alternativa de usar un bucle y limitar el numero de llamadas.
    private void CallMe(int i)
    {
        if (i == 4) return;
        Debug.Log(i);
        i++;
        CallMe(i);
    }

    #endregion

    private void GenerateTree()
    {
        if (currentDepth >= recursionDepht) return;
        ++currentDepth;

        currentLenght -= rootLenght * reductionLenghtFactor;
        currentLenght = Mathf.Max(currentLenght, 0.1f);
        List<GameObject> levelNodes = new List<GameObject>();

        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            GameObject leftBranch = GenerateBranch(branch, Random.Range(10f,30f)); 
            GameObject rightBranch = GenerateBranch(branch, -Random.Range(10f, 30f));

            levelNodes.Add(leftBranch);
            levelNodes.Add(rightBranch);
        }

        foreach (GameObject node in levelNodes)
        {
            frontier.Enqueue(node);
        }

        GenerateTree();
    }
    private float GetBranchLength(GameObject branch)
    {
        Transform line = branch.transform.GetChild(1);
        return line.localScale.y;

    }
    private GameObject GenerateBranch(GameObject prevBranch, float angle)
    {
        GameObject branch = Instantiate(branchPrefab, transform);
        
        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up * GetBranchLength(prevBranch);
        Quaternion prevRotation = prevBranch.transform.rotation;
        SetBranchLenght(branch, currentLenght);

        prevRotation *= Quaternion.Euler(0, 0, angle);  
        branch.transform.rotation = prevRotation;
       
        return branch;
    }

    private void SetBranchLenght(GameObject branch, float lenght)
    {
        Transform line = branch.transform.GetChild(1);
        Transform circle = branch.transform.GetChild(0);
        line.localScale = new Vector3(line.localScale.x, lenght, line.localScale.z);
        line.localPosition = new Vector3(0, lenght * 0.5f, 0);
        circle.localPosition = new Vector3(0, lenght, 0);
    }
}
