
/*
   
    Notes

    - Each actor needs a way of tracking the type of space it has and comparing it to the type of space it wants.
    - Ideally this should just be a matter of summing up attributes over the tiles it has placed.

    TODO

    - Finish implementation

*/

using UnityEngine;

namespace RC3.DigitalNomad
{
    /// <summary>
    /// Represents an actor that chooses tiles to be placed
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/Actor")]
    public class NomadActor : ScriptableObject
    {
        private int[] _tilesRemaining; // The number of remaining tiles (of each type)
        private int[] _tilesPlaced; // The number of placed tiles (of each type)

        // ...
        // ...
        // ...
    }
}
