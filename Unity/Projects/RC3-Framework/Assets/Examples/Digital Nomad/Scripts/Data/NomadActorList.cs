
/*
   
    Notes

*/

using System.Collections.Generic;
using UnityEngine;

namespace RC3.DigitalNomad
{
    /// <summary>
    /// Contains all actors in the scene.
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/Actor List")]
    public class NomadActorList : ScriptableObject
    {
        [SerializeField] private List<NomadActor> _actors;

        // TODO: If specified, should automatically load actors from this location (avoids manual setup)
        [SerializeField] private string _path;

        public List<NomadActor> Actors
        {
            get { return _actors; }
        }
    }
}
