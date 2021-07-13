using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
  public GameObject ball;
  private Vector3 _offset;
  // Start is called before the first frame update
  void Start()
  {
    _offset = transform.position - ball.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = ball.transform.position + _offset;
  }
}
