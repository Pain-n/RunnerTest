using System;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public float Speed;

    public int Flames { get; private set; }

    public static Action SpawnEnvironment;
    public static Action<int> FlameChanged;
    public static Action EndGame;

    private void Start()
    {
        Flames = 3;
        FlameChanged?.Invoke(0);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 1 * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Environment":
                SpawnEnvironment?.Invoke();
                break;
            case "Water":
                other.enabled = false;
                if (Flames != 0) Flames--;
                if(Flames == 0)
                {
                    EndGame?.Invoke();
                    break;
                }
                FlameChanged?.Invoke(0);
                break;
            case "Flame":
                other.enabled = false;
                if (Flames < 6)
                {
                    Flames++;
                }
                FlameChanged?.Invoke(1);
                Destroy(other.gameObject);
                break;
        }
    }
}
