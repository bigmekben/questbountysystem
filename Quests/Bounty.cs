using UnityEngine;

// This bounty system only supports 1 trackable property per bounty.
// but, perhaps rename this to BountyPart and make Bounty a smart collection of BountyParts.
public class Bounty : ProgressionTracker, ICreditObserver
{
    // each Bounty subclass must implement the observer functions it needs.

    [Header("Configuration")]
    public string label; // e.g., "Red squares collected"
    public string trackedProperty; // e.g., "RedSquaresCollected"
    public int max;  // e.g., 10 if the goal is accomplishing 10 of something

    private int current;

    // some day, switch to only looking at the delta so that multiple bounties can read the same property.
    // for now, assume that no two bounties track the same property.

    public override void Subscribe(ICreditObserver observer)
    {
        AccomplishmentTracker.AddObserverForCreditRedSquare(trackedProperty, observer);
    }

    public override string DetailsToDisplay() => $"{label}: {current} / {max}";

    public override int Max() => max;

    public override bool IsDone() => current >= max;

    public override void Credit()
    {
        current = AccomplishmentTracker.GetProperty(trackedProperty);
        if (current > max)
            current = max;
    }
}