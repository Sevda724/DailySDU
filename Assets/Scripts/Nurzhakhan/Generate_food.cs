using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Generate_food : MonoBehaviour
{
    int timer = 0;
    public int food_index = 0;
    public int food_index_second = 0;
    public GameObject[] food_prefabs;
    GameObject food_prefab;
    GameObject food_prefab_second;
    GameObject food_prefab_third;
    bool game_play_gf = false;
    Player_script player_script;

    public GameObject[] addition;
    GameObject add_prefab;
    int i = 1;
    int generate_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject game_over = GameObject.Find("Player");
        player_script = game_over.GetComponent<Player_script>();

    }

    // Update is called once per frame
    public void Update()
    {
        timer += 1;

        game_play_gf = player_script.game_play;

        if (timer >= 100 && game_play_gf)
        {
            generate_num++;
            Debug.Log("Generate num: " + generate_num);
            if (i % 3 == 0)
            {

                add_prefab = addition[0];
                GameObject add_clone = Instantiate(add_prefab, new Vector2(Random.Range(-7, 7),
                Random.Range(1, 3)), Quaternion.identity);
                Destroy(add_clone, 5);
            }
            else
            {
                add_prefab = addition[1];
                GameObject add_clone = Instantiate(add_prefab, new Vector2(Random.Range(-7, 7),
                Random.Range(1, 3)), Quaternion.identity);
                Destroy(add_clone, 5);
            }
            food_prefab = food_prefabs[Random.Range(0, 7)];
            food_prefab_second = food_prefabs[Random.Range(0, 7)];
            food_prefab_third = food_prefabs[Random.Range(0, 7)];

            GameObject food_clone = Instantiate(food_prefab, new Vector2(Random.Range(-7, -4),
                 Random.Range(1, 3)), Quaternion.identity);
            GameObject food_clone_second = Instantiate(food_prefab_second, new Vector2(Random.Range(-3, 5),
                Random.Range(1, 3)), Quaternion.identity);
            GameObject food_clone_third = Instantiate(food_prefab_third, new Vector2(Random.Range(6, 8),
                Random.Range(1, 3)), Quaternion.identity);
            i++;
            timer = 0;
            Destroy(food_clone, 5);
            Destroy(food_clone_second, 5);
            Destroy(food_clone_third, 5);
        }
    }
    IEnumerator FewSeconds()
    {
        yield return new WaitForSeconds(1f);

    }

}
