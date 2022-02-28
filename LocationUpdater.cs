using UnityEngine;
using System.Collections;

public class LocationUpdater : MonoBehaviour
{
    public float IntervalSeconds = 1.0f;
    public LocationServiceStatus Status;
    public LocationInfo Location;

    IEnumerator Start()
    {
        while (true)
        {
            this.Status = Input.location.status;
            if (Input.location.isEnabledByUser)
            {
                switch (this.Status)
                {
                    case LocationServiceStatus.Stopped:
                        Input.location.Start();
                        break;
                    case LocationServiceStatus.Running:
                        this.Location = Input.location.lastData;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // FIXME �ʒu����L���ɂ���!! �I�ȃ_�C�A���O�̕\������������Ɨǂ�����
                Debug.Log("location is disabled by user");
            }

            // �w�肵���b����ɍēx����𑖂点��
            yield return new WaitForSeconds(IntervalSeconds);
        }
    }
}