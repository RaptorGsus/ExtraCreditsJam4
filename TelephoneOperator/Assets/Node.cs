using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Node : MonoBehaviour
{
    [SerializeField]
    protected string addition;
    abstract public string Visit(ref string expression);
}
