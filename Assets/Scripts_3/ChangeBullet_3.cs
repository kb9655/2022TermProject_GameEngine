using UnityEngine;

public class ChangeBullet_3 : MonoBehaviour
{
  public int bulletNum;
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      Shooter_3.flag = bulletNum;
      Destroy(this.gameObject);
    }
  }
}
