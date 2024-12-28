using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System.IO;

public class GamePlay : MonoBehaviour
{
    Vector2 MousePosition;
    Camera Camera;
    public Grid grid;
    public Tilemap tilemap;
    public AnimatedTile blue_Player;
    public AnimatedTile red_Player;
    public AnimatedTile blue_Tile;
    public AnimatedTile red_Tile;
    public AnimatedTile blue_Player_Ani;
    public AnimatedTile red_Player_Ani;
    public AnimatedTile blue_Tile_Ani;
    public AnimatedTile red_Tile_Ani;
    private bool isBlueTurn = true;
    private Vector3Int preBluePosition = new Vector3Int(-6,-6,0);
    private Vector3Int preRedPosition = new Vector3Int(5,-6,0);
    // Start is called before the first frame update
    int[,] map = new int[14, 14];

    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        tilemap.SetTile(preBluePosition, blue_Player_Ani);
        tilemap.SetTile(preRedPosition, red_Player_Ani);
        resetMap(map);
        //기본 시작 위치(변경가능)
        map[preBluePosition.x + 7, preBluePosition.y + 7] = 1;
        map[preRedPosition.x + 7, preRedPosition.y + 7] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int endTilePosition = tilemap.WorldToCell(worldPosition);
            
            MoveTile(isBlueTurn ? preBluePosition : preRedPosition, endTilePosition);
        }
    }

    //타일 이동
    void MoveTile(Vector3Int fromPosition, Vector3Int toPosition){
        if(Mathf.Abs(fromPosition.x -toPosition.x) <= 1 && Mathf.Abs(fromPosition.y -toPosition.y) <= 1 && tilemap.GetTile(fromPosition) != null && tilemap.GetTile(toPosition) == null
            && toPosition.x < 6 && toPosition.y < 6 && toPosition.x >= -6 && toPosition.y >= -6)
        {
            tilemap.SetTile(toPosition, isBlueTurn ? blue_Player : red_Player);
            tilemap.SetTile(fromPosition, isBlueTurn ? blue_Tile : red_Tile);
            tilemap.SetAnimationFrame(toPosition, 0);
            tilemap.SetAnimationFrame(fromPosition, 0);
            StartCoroutine(changeAni(fromPosition, toPosition, isBlueTurn));
            map[toPosition.x + 7, toPosition.y + 7] = 1;
            if (isBlueTurn) {preBluePosition = toPosition; isBlueTurn = false;}
            else {preRedPosition = toPosition; isBlueTurn = true; }
            isWin(toPosition);
        }
    }

    //타일 애니메이션 변경
    IEnumerator changeAni(Vector3Int Tile, Vector3Int Player, bool isBlueTurn)
    {
        yield return new WaitForSeconds(0.5f); // 1초 대기
        tilemap.SetTile(Player, isBlueTurn ? blue_Player_Ani : red_Player_Ani);
        tilemap.SetTile(Tile, isBlueTurn ? blue_Tile_Ani : red_Tile_Ani);
    }

    //승리판정
    void isWin(Vector3Int position) {
        int count = 0;
        for (int x = position.x + 6; x <= position.x + 8; x++) {
            for (int y = position.y + 6; y <= position.y + 8; y++) {
                if (map[x, y] == 1) count++;
            }
        }
        if(count > 8) {
            if (isBlueTurn)
            {
                Debug.Log("gameover Blue win");
            }
            else if (!isBlueTurn)
            {
                Debug.Log("gameover Red win");
            }
        }
    }

    //게임 초기화
    void resetMap(int[,] arr) {
        for (int i = 1; i < 13; i++)
        {
            for (int j = 1; j < 13; j++)
            {
                arr[i, j] = 0;
            }
        }
        for (int i = 0; i < 14; i++) {
            arr[i, 0] = 1;
            arr[i, 13] = 1;
            arr[0, i] = 1;
            arr[13, i] = 1;
        }
        tilemap.ClearAllTiles();
        tilemap.SetTile(new Vector3Int(-6, -6, 0), blue_Player_Ani);
        tilemap.SetTile(new Vector3Int(5, -6, 0), red_Player_Ani);
    }
}
