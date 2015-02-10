using CC.Debug;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private IInputManager _inputManager;
    private GameActor _playerActor;

    void Awake()
    {
        _inputManager = PlayerInputManager.Instance;
        _playerActor = GetComponent<GameActor>();

        Require.That(_playerActor, "_playerActor").IsNotNull();
    }

	// Update is called once per frame
	void Update ()
	{
	    var commands = _inputManager.GetCommands();
	    for (int i = 0; i < commands.Length; i++)
	    {
	        commands[i].Execute(_playerActor);
	    }
	}
}
