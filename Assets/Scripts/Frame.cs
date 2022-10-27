using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame
{
    public int ID_Frame;
    public string thingId;
    public List<People> People;

    public List<People> getPeopleList() { return this.People;}
}
