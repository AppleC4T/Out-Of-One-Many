using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileLogic : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public Material highlight;
    public Material pathHighlight;
    public Material startingMaterial;
    public Material pathMaterial;
    public GameObject tower;
    public bool isOccupied = false;
    public enemySpawner spawner;
    public bool isPath = false;
    public bool canBePath = false;
    public makePath pathLogic;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        startingMaterial = MeshRenderer.material;
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<enemySpawner>();
        pathLogic = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<makePath>();

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (spawner.isWaveFinished == true && isPath == false && pathLogic.isPathMade == true)
        {
            MeshRenderer.material = highlight;
        }
    }

    void OnMouseExit()
    {
        if (isPath == false)
        {
            MeshRenderer.material = startingMaterial;
        }
    }

    void OnMouseUpAsButton()
    {


        if (spawner.isWaveFinished == true && isPath == false && pathLogic.isPathMade == true)
        {
            if (isOccupied == false && GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>().health > 1)
            {
                Instantiate(tower, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
                isOccupied = true;
                GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>().health -= 1;
            }
        }
    }

}
