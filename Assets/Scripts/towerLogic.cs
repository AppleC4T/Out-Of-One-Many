using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerLogic : MonoBehaviour
{
    public int level = 1;
    public float startTimeBtwShots = 1f;
    private float timeBtwShots;
    public Collider[] enemiesInRange;
    public LayerMask enemiesLayer;
    public Collider tileUnder;
    public LayerMask tiles;
    public enemySpawner spawner;
    public Mesh[] stagesMesh;
    public MeshFilter meshFilter;
    public float damage;
    public int range;
    public castleLogic castle;
    public GameObject arrow;
    public GameObject effectF;
    public GameObject effectB;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
        timeBtwShots = startTimeBtwShots;
        tileUnder = Physics.OverlapBox(transform.position, new Vector3(1f,3.5f,1f), Quaternion.identity, tiles)[0];
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<enemySpawner>();
        meshFilter = GetComponent<MeshFilter>();
        castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<castleLogic>();
        audio = GameObject.FindGameObjectWithTag("build").GetComponent<AudioSource>();
        Instantiate(effectB, (castle.transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
        Instantiate(effectF, (transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
        audio.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemiesInRange = Physics.OverlapBox(transform.position, new Vector3(((range*2) + 2f), 6f, ((range*2) + 2f)), Quaternion.identity, enemiesLayer);
        if (enemiesInRange.Length > 0)
        {
            for (int i = 0; i < enemiesInRange.Length; i++)
            {
                if (timeBtwShots <= 0f)
                {
                    GameObject shotArrow = Instantiate(arrow, transform.position, Quaternion.identity);
                    shotArrow.GetComponent<arrowFollow>().target = enemiesInRange[i].transform;
                    enemiesInRange[i].GetComponent<enemyLogic>().health -= damage;
                    timeBtwShots = startTimeBtwShots;
                }
            }
        }
    }

    void Update()
    {
        timeBtwShots -= Time.deltaTime;

        if (level == 1)
        {
            damage = 0.4f;
            range = 1;
        }
        else if (level == 2)
        {
            damage = 0.75f;
            range = 2;
        }
        else if (level == 3)
        {
            damage = 1.2f;
            range = 4;
        }

        if (level == 1)
        {
            meshFilter.mesh = stagesMesh[0];
        }else if (level == 2)
        {
            meshFilter.mesh = stagesMesh[1];
        }else if (level == 3)
        {
            meshFilter.mesh = stagesMesh[2];
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && spawner.isWaveFinished == true)
        {
            if (level == 1)
            {
                Instantiate(effectB, (transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                Instantiate(effectF, (castle.transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                audio.Play();
                castle.health += 1;
                tileUnder.gameObject.GetComponent<tileLogic>().isOccupied = false;
                Destroy(gameObject);
            }
            else if (level == 2)
            {
                Instantiate(effectB, (transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                Instantiate(effectF, (castle.transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                audio.Play();
                level--;
                castle.health += 2;
            }
            else if (level == 3)
            {
                Instantiate(effectB, (transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                Instantiate(effectF, (castle.transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
                audio.Play();
                level--;
                castle.health += 2;
            }
        }else if (Input.GetMouseButtonDown(0) && spawner.isWaveFinished == true && castle.health > level + 1 && level < 3)
        {
            Instantiate(effectB, (castle.transform.position + new Vector3(0f, 7f, 0f)), Quaternion.identity);
            castle.health -= level + 1;
            Instantiate(effectF, (transform.position + new Vector3(0f,7f,0f)), Quaternion.identity);
            audio.Play();
            level++;    
        }

    }

    
    
        
    


}
