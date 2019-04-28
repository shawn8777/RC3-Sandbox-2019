using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;


namespace RC3.TilingDemo
{
    public static class Utilities
    {
        /// <summary>
        /// Binary serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="path"></param>
        public static void SerializeBinary<T>(T item, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, item);
            }
        }


        /// <summary>
        /// Binary deserialization
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object DeserializeBinary(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }


        /// <summary>
        /// Binary deserialization
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeBinary<T>(string path)
        {
            return (T)DeserializeBinary(path);
        }


        /// <summary>
        /// 
        /// </summary>
        private static Vector3[] _cubeFaceCenters = new Vector3[]
        {
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, 1.0f)
        };


        /// <summary>
        /// 
        /// </summary>
        private static Vector3[] _cubeFaceNormals = new Vector3[]
        {
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, 1.0f)
        };


        /// <summary>
        /// Returns a hash code for each face of the cube
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static int[] GetLabelsCubic(Mesh mesh)
        {
            // TODO: Generalize - return hash from list of triangles sitting on a face

            throw new NotImplementedException();

            var areaSum = new float[6];
            var centroidSum = new Vector3[6];

            var indices = mesh.triangles;
            var vertices = mesh.vertices;

            // for(int i = 0; i < )

            
            return null;
        }
    }
}
