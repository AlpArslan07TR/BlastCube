using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services
{
    [CreateAssetMenu(fileName = "ImageData", menuName = "Scriptable Objects/ImageData")]
    public class ImageDataSO : MonoBehaviour
    {
        [Header("Red Cubes")]
        public Sprite redCube;
        public Sprite redCubeRocket;
        public Sprite redCubeBomb;
        public Sprite redCubeDisco;

        [Space,Header("Green Cubes")]
        public Sprite GreenCube;
        public Sprite GreenCubeRocket;
        public Sprite GreenCubeBomb;
        public Sprite GreenCubeDisco;
        
        [Space, Header("Blue Cubes")]
        public Sprite BlueCube;
        public Sprite BlueCubeRocket;
        public Sprite BlueCubeBomb;
        public Sprite BlueCubeDisco;

        [Space, Header("Yellow Cubes")]
        public Sprite YellowCube;
        public Sprite YellowCubeRocket;
        public Sprite YellowCubeBomb;
        public Sprite YellowCubeDisco;

        [Space, Header("Pink Cubes")]
        public Sprite PinkCube;
        public Sprite PinkCubeRocket;
        public Sprite PinkCubeBomb;
        public Sprite PinkCubeDisco;

        [Space, Header("Purple Cubes")]
        public Sprite PurpleCube;
        public Sprite PurpleCubeRocket;
        public Sprite PurpleCubeBomb;
        public Sprite PurpleCubeDisco;

        [Space, Header("Balloons")]
        public Sprite balloon;
        public Sprite balloonGreen;
        public Sprite balloonRed;
        public Sprite balloonBlue;
        public Sprite balloonYellow;
        public Sprite balloonPink;
        public Sprite balloonPurple;

        [Space, Header("Creates")]
        public Sprite createLayer1;
        public Sprite createLayer2;

        [Space, Header("Rockets")]
        public Sprite rocketVertical;
        public Sprite rocketHorizontal;

        [Space, Header("Bomb")]
        public Sprite bomb;

        [Space, Header("Disco")]
        public Sprite disco;

    }
}

