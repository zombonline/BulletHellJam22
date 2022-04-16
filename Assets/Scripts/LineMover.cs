using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LineMover : MonoBehaviour
{
    [SerializeField] Transform pos1, pos2;

    [SerializeField] bool lockXToPos1, lockYToPos1;
    LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        line.SetPosition(1, pos1.position);
        line.SetPosition(0, pos2.position);
    }

    private void Update()
    {
        if(lockXToPos1)
        {

            line.SetPosition(0, new Vector2(pos1.position.x, pos2.position.y));
            line.SetPosition(1, pos1.position);

        }
        else if (lockYToPos1)
        {
            line.SetPosition(0, new Vector2(pos2.position.x, pos1.position.y));
            line.SetPosition(1, pos1.position);

        }
        else
        {
            line.SetPosition(1, pos1.position);
            line.SetPosition(0, pos2.position);

        }
    }

}
