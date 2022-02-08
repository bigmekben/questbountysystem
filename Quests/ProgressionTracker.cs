using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgressionTracker: MonoBehaviour
{
    public abstract string DetailsToDisplay();
    public abstract int Max();
    public abstract bool IsDone();
    public abstract void Credit();
    public abstract void Subscribe(ICreditObserver observer);
}