using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    GameObject Take();
    void Return(GameObject gameObjectToReturn);
}
