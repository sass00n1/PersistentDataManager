using UnityEngine;
using SFTool;

public class PlayerInput : MonoBehaviour, IDataPersister
{
    private CharacterController2D cc2D;

    private float horizontalMove;
    private bool isJump;

    //持久化相关
    private int score;
    [SerializeField] private DataSettings dataSettings;

    private void Awake()
    {
        cc2D = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        //移动
        horizontalMove = Input.GetAxisRaw("Horizontal") * 40;
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        cc2D.Move(horizontalMove * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }

    private void OnEnable()
    {
        PersistentDataManager.RegisterPersister(this);
    }

    private void OnDisable()
    {
        PersistentDataManager.UnregisterPersister(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 1;
            Destroy(other.gameObject);
        }
    }

    //======================= 持久化接口相关 =======================//

    public DataSettings GetDataSettings()
    {
        return dataSettings;
    }

    public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
    {
        dataSettings.dataTag = dataTag;
        dataSettings.persistenceType = persistenceType;
    }

    public Data SaveData()
    {
        return new Data<int>(score);
    }

    public void LoadData(Data data)
    {
        Data<int> MpData = (Data<int>)data;
        score = MpData.value;

        Debug.Log($"上一关保存的分数：{score}");
    }
}
