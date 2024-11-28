using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float torque = 10.0f;
    private float xRange = 4.0f;
    private float spawnPositionY = -2.0f;
    private float destroyBoundry = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());


        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        FallingDestroy();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }


    Vector3 RandomSpeed()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), spawnPositionY);
    }

    public void FallingDestroy()
    {
        // 코루틴을 시작하여 주기적으로 y값을 검사
        StartCoroutine(CheckPositionPeriodically());
    }

    private IEnumerator CheckPositionPeriodically()
    {
        while (true)
        {
            // y축 위치가 기준 아래로 내려가면 삭제
            if (transform.position.y < destroyBoundry)
            {
                Destroy(gameObject);
                yield break; // 오브젝트 삭제 후 코루틴 종료
            }

            yield return new WaitForSeconds(3.0f); // 3초마다 검사
        }
    }
}
