//using UnityEngine;

//public class Projectile : MonoBehaviour
//{
//    public float speed = 10f;
//    public float lifeTime = 3f;

//    private Vector3 direction;

//    public void SetDirection(Vector3 dir)
//    {
//        direction = dir.normalized;
//        Destroy(gameObject, lifeTime);
//    }

//    void Update()
//    {
//        transform.position += direction * speed * Time.deltaTime;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        Destroy(gameObject);
//    }
//}
