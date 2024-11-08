using Assets.Scripts.Adapters;
using Assets.Scripts.Data;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private static PlayerCore instance;
    private PlayerData data;
    private InputAdapter inputAdapter;
    private MovementAdapter movementAdapter;
    private AnimationAdapter animationAdapter;
    private EnergeManagement energeManagement;

    public PlayerData PlayerData { get { return data; }  private set { } }
    public InputAdapter InputAdapter { get { return inputAdapter; } private set { } }
    public MovementAdapter MovementAdapter { get { return movementAdapter; } private set { } }
    public AnimationAdapter AnimationAdapter { get { return animationAdapter; } private set { } }
    public EnergeManagement EnergeManagement { get { return energeManagement; } private set { } }
    public static PlayerCore Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) { instance = this; }
        
        data = GetComponent<PlayerData>();
        inputAdapter = GetComponent<InputAdapter>();
        movementAdapter = GetComponent<MovementAdapter>();
        animationAdapter = GetComponent<AnimationAdapter>();
        energeManagement = GetComponent<EnergeManagement>();
    }
}
