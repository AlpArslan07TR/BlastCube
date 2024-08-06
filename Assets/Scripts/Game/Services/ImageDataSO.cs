using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services
{
    [CreateAssetMenu(fileName = "ImageData", menuName = "Scriptable Objects/ImageData")]
    public class ImageDataSO : MonoBehaviour
    {
        [Header("Red Cubes")]
        [SerializeField] private Sprite redCube;
        [SerializeField] private Sprite redCubeRocket;
        [SerializeField] private Sprite redCubeBomb;
        [SerializeField] private Sprite redCubeDisco;

        [Space,Header("Green Cubes")]
        [SerializeField] private Sprite GreenCube;
        [SerializeField] private Sprite GreenCubeRocket;
        [SerializeField] private Sprite GreenCubeBomb;
        [SerializeField] private Sprite GreenCubeDisco;
        
        [Space, Header("Blue Cubes")]
        [SerializeField] private Sprite BlueCube;
        [SerializeField] private Sprite BlueCubeRocket;
        [SerializeField] private Sprite BlueCubeBomb;
        [SerializeField] private Sprite BlueCubeDisco;

        [Space, Header("Yellow Cubes")]
        [SerializeField] private Sprite YellowCube;
        [SerializeField] private Sprite YellowCubeRocket;
        [SerializeField] private Sprite YellowCubeBomb;
        [SerializeField] private Sprite YellowCubeDisco;

        [Space, Header("Pink Cubes")]
        [SerializeField] private Sprite PinkCube;
        [SerializeField] private Sprite PinkCubeRocket;
        [SerializeField] private Sprite PinkCubeBomb;
        [SerializeField] private Sprite PinkCubeDisco;

        [Space, Header("Purple Cubes")]
        [SerializeField] private Sprite PurpleCube;
        [SerializeField] private Sprite PurpleCubeRocket;
        [SerializeField] private Sprite PurpleCubeBomb;
        [SerializeField] private Sprite PurpleCubeDisco;

        [Space, Header("Balloons")]
        [SerializeField] private Sprite balloon;
        [SerializeField] private Sprite balloonGreen;
        [SerializeField] private Sprite balloonRed;
        [SerializeField] private Sprite balloonBlue;
        [SerializeField] private Sprite balloonYellow;
        [SerializeField] private Sprite balloonPink;
        [SerializeField] private Sprite balloonPurple;

        [Space, Header("Creates")]
        [SerializeField] private Sprite createLayer1;
        [SerializeField] private Sprite createLayer2;

        [Space, Header("Rockets")]
        [SerializeField] private Sprite rocketVertical;
        [SerializeField] private Sprite rocketHorizontal;

        [Space, Header("Bomb")]
        [SerializeField] private Sprite bomb;

        [Space, Header("Disco")]
        [SerializeField] private Sprite disco;

    }
}

