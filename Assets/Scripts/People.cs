using System;
using System.Collections.Generic;
[Serializable]
/*
 * Questione vettore people del json ditto.
 * Il vettore people dovrebbe essre una classe che contiene una lista di 
 * DESERIALIZED CLASS
 */
public class People
{
    public int personID;
    public List<Skeleton> skeleton;
    public People()
    {
        skeleton = new List<Skeleton>();
    }

    public List<Skeleton> GetSkeletonList() { return this.skeleton; }
}