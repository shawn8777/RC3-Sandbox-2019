﻿using UnityEngine;

namespace RC3
{

    /// <summary>
    /// 
    /// </summary>
    public static class ImageSynthesizer
    {
        /// <summary>
        /// Sample half of each image and combine to a new image (left,right)
        /// </summary>
        /// <param name="texture1"></param>
        /// <param name="texture2"></param>
        public static void CombineHalf1(Texture2D texture1, Texture2D texture2)
        {
            var output = new Texture2D((texture1.width / 2) + (texture2.width / 2), texture1.height, TextureFormat.ARGB32, false);

            for (int i = 0; i < texture1.width / 2; i++)
            {
                for (int j = 0; j < texture1.height; j++)
                {
                    output.SetPixel(i, j, texture1.GetPixel(i, j));
                }
            }
            for (int i = texture2.width / 2; i < texture2.width; i++)
            {
                for (int j = 0; j < texture1.height; j++)
                {
                    output.SetPixel(i, j, texture2.GetPixel(i, j));
                }
            }
        }


        /// <summary>
        /// Sample half of each image and combine to a new image (bottom,top)
        /// </summary>
        public static void CombineHalf2(Texture2D texture1, Texture2D texture2)
        {
            var output = new Texture2D(texture1.width, (texture1.height / 2) + (texture2.height / 2), TextureFormat.ARGB32, false);

            for (int i = 0; i < texture1.width; i++)
            {
                for (int j = 0; j < texture1.height / 2; j++)
                {
                    output.SetPixel(i, j, texture1.GetPixel(i, j));
                }
            }
            for (int i = 0; i < texture1.width; i++)
            {
                for (int j = texture2.height / 2; j < texture2.height; j++)
                {
                    output.SetPixel(i, j, texture2.GetPixel(i, j));
                }
            }
        }

        /// <summary>
        /// Sample 2 quarters of each image and combine to a new image
        /// </summary>
        public static void CombineQuarters1(Texture2D texture1, Texture2D texture2)
        {

        }


        /// <summary>
        /// Sample 2 quarters of each image and combine to a new image
        /// </summary>
        public static void CombineQuarters2(Texture2D texture1, Texture2D texture2)
        {

        }


    }
}