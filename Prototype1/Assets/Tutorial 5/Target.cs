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
        // �ڷ�ƾ�� �����Ͽ� �ֱ������� y���� �˻�
        StartCoroutine(CheckPositionPeriodically());
    }

    private IEnumerator CheckPositionPeriodically()
    {
        while (true)
        {
            // y�� ��ġ�� ���� �Ʒ��� �������� ����
            if (transform.position.y < destroyBoundry)
            {
                Destroy(gameObject);
                yield break; // ������Ʈ ���� �� �ڷ�ƾ ����
            }

            yield return new WaitForSeconds(3.0f); // 3�ʸ��� �˻�
        }
    }
}
