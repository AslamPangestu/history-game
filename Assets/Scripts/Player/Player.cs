using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 damping;
        public Vector2 sensitivity;
    }
    [SerializeField] float speed;
    [SerializeField] MouseInput mouseControl;

    InputController playerInput;
    Vector2 mouseInput;

    private MoveController m_PlayerMove;
    public MoveController playerMove
    {
        get
        {
            if(m_PlayerMove == null)
            {
                m_PlayerMove = GetComponent<MoveController>();
            }
            return m_PlayerMove;
        }
    }

    //private Crosshair m_Crosshair;
    //public Crosshair Crosshair
    //{
    //    get
    //    {
    //        if (m_Crosshair == null)
    //        {
    //            m_Crosshair = GetComponentInChildren<Crosshair>();
    //        }
    //        return m_Crosshair;
    //    }
    //}
    // Use this for initialization
    void Start () {

	}

    private void Awake()
    {
        playerInput = GamesManager.Instance.InputController;
        GamesManager.Instance.LocalPlayer = this;
    }

    // Update is called once per frame
    void Update () {
        Vector2 direction = new Vector2(playerInput.vertical * speed, 
            playerInput.horizontal * speed);
        playerMove.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x,
            playerInput.mouseInput.x,
            1f / mouseControl.damping.x);
        //mouseInput.y = Mathf.Lerp(mouseInput.y,
        //    playerInput.mouseInput.y, 
        //    1f / mouseControl.damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * 
            mouseControl.sensitivity.x);

        //Crosshair.LookHeight(mouseInput.y * mouseControl.sensitivity.y);
	}
}
