using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool isNext { get; set; }
    public int MaxSeedNo { get; private set; }

    [SerializeField] private seed[] seedPrefab;
    [SerializeField] private Transform seedPosition;
    [SerializeField] private Text txtScore;

    private int totalscore;

    //DiseRollManeger系の変数の取得
    [SerializeField] public GameObject DiseRollManeger;
    [SerializeField] public int getdicenum;

    void Start()
    {
        Instance = this;
        isNext = false;
        MaxSeedNo = seedPrefab.Length;
        totalscore = 0;
        SetScore(totalscore);
        CreateSeed();
    }
    void Update()
    {
        if (isNext)
        {
            isNext = false;
            Invoke("CreateSeed", 2f);
        }
    }
    private void CreateSeed()
    {
        int i = Random.Range(0, MaxSeedNo - 2);
        seed seedIns = Instantiate(seedPrefab[i], seedPosition);
        seedIns.seedNo = i;
        seedIns.gameObject.SetActive(true);
    }
    public void MergeNext(Vector3 target, int seedNo)
    {
        seed seedIns = Instantiate(seedPrefab[seedNo + 1], target, Quaternion.identity, seedPosition);
        seedIns.seedNo = seedNo + 1;
        seedIns.isDrop = true;
        seedIns.GetComponent<Rigidbody2D>().simulated = true;
        seedIns.gameObject.SetActive(true);

        //ダイスロールして点数を変更

        DiseRollScript.Instance.NextRoll = true;
        //while (DiseRollScript.Instance.culcOK)
        //{
        //    Invoke("aaa",0.5f);
        //}
        getdicenum = DiseRollScript.Instance.ForculcNum;
        Debug.Log(getdicenum);

        //ダイスロール関係処理ここまで

        totalscore += (int)Mathf.Pow(3, seedNo) * getdicenum;
        SetScore(totalscore);
    }

    //IEnumerator<float> MyLoop()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //}

    private void aaa()
    {
        Debug.Log("aaa");
    }

    private void SetScore(int score)
    {
        txtScore.text = score.ToString();
    }

}