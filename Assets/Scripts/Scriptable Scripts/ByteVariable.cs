using UnityEngine;

[CreateAssetMenu(fileName = "ByteVariable", menuName = "Variables/ByteVariable", order = 2)]
public class ByteVariable : ScriptableObject
{
    public byte value;

    public void SetValue(int val)
    {
        value =(byte) val;
    }
}