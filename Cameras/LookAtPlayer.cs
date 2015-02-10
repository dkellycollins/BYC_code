using UnityEngine;
using System.Collections;

namespace CC.Cameras
{
    public class LookAtPlayer : MonoBehaviour
    {
        private Transform _player;

        // Use this for initialization
        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _player = player.transform;
            }
            else
            {
                UnityEngine.Debug.Log("Player not found.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(_player);
        }
    }
}
