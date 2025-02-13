using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

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
    public AnimatedTile blue_PTile;
    public AnimatedTile red_PTile;
    public AnimatedTile blue_Player_Ani;
    public AnimatedTile red_Player_Ani;
    public AnimatedTile blue_Tile_Ani;
    public AnimatedTile red_Tile_Ani;
    private bool isBlueTurn = true;
    private Vector3Int preBluePosition = new Vector3Int(-6,-6,0);
    private Vector3Int preRedPosition = new Vector3Int(5,5,0);
    public static int WinFlag = 0; // 승리 플래그
    int[,] map = new int[14, 14];
    public static bool isGamePaused { get; set; } = false;

    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        tilemap.SetTile(preBluePosition, blue_Player_Ani);
        tilemap.SetTile(preRedPosition, red_Player_Ani);
        resetMap();
        //기본 시작 위치(변경가능)
        map[preBluePosition.x + 7, preBluePosition.y + 7] = 1;
        map[preRedPosition.x + 7, preRedPosition.y + 7] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused) return;
        wayToGo(isBlueTurn ? preBluePosition: preRedPosition); // 이동가능타일 표기
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int endTilePosition = tilemap.WorldToCell(worldPosition);

            resetZeroTile(isBlueTurn ? preBluePosition : preRedPosition); // 표기한 이동가능타일 초기화
            MoveTile(isBlueTurn ? preBluePosition : preRedPosition, endTilePosition); // 타일 이동
        }
    }


    //타일 이동
    void MoveTile(Vector3Int fromPosition, Vector3Int toPosition) {
        if (Mathf.Abs(fromPosition.x - toPosition.x) <= 1 && Mathf.Abs(fromPosition.y - toPosition.y) <= 1 && tilemap.GetTile(fromPosition) != null && tilemap.GetTile(toPosition) == null
            && toPosition.x < 6 && toPosition.y < 6 && toPosition.x >= -6 && toPosition.y >= -6)
        {
            tilemap.SetTile(toPosition, isBlueTurn ? blue_Player : red_Player); //전 위치에 타일 변경
            tilemap.SetTile(fromPosition, isBlueTurn ? blue_Tile : red_Tile); //후 위치에 플레이어 이동
            tilemap.SetAnimationFrame(toPosition, 0); //타일 애니메이션 재생
            tilemap.SetAnimationFrame(fromPosition, 0);
            StartCoroutine(changeAni(fromPosition, toPosition, isBlueTurn)); //타일 애니메이션 변경 코루틴
            map[toPosition.x + 7, toPosition.y + 7] = 1; // 맵 배열에 플레이어 설정
            if (isBlueTurn) { preBluePosition = toPosition; isBlueTurn = false; } // 순서플래그에 따른 변수 변경
            else { preRedPosition = toPosition; isBlueTurn = true; }
            SoundsControl.Drawing();
            isWin(toPosition); // 승리 판정
        }
        else { SoundsControl.CantMove(); }
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
        //position의 근처 9칸 합해서 8 초과시 승리판정
        int count = 0; 
        for (int x = position.x + 6; x <= position.x + 8; x++) {
            for (int y = position.y + 6; y <= position.y + 8; y++) {
                if (map[x, y] == 1) count++;
            }
        }
        if(count > 8) {
            if (isBlueTurn)
            {
                WinFlag = 1;
                Debug.Log("gameover Blue win");
            }
            else if (!isBlueTurn)
            {
                WinFlag = 2;
                Debug.Log("gameover Red win");
            }
        }
    }

    //게임 초기화
    public void resetMap() {
        for (int i = 1; i < 13; i++)
        {
            for (int j = 1; j < 13; j++)
            {
                map[i, j] = 0;
            }
        }
        for (int i = 0; i < 14; i++) {
            map[i, 0] = 1;
            map[i, 13] = 1;
            map[0, i] = 1;
            map[13, i] = 1;
        }
        tilemap.ClearAllTiles(); // 보드판 초기화
        isBlueTurn = true; //차례 초기화
        preBluePosition = new Vector3Int(-6, -6, 0); // 플레이어위치 초기화
        preRedPosition = new Vector3Int(5, 5, 0);
        tilemap.SetTile(preBluePosition, blue_Player_Ani); // 플레이어위치에 타일 위치
        tilemap.SetTile(preRedPosition, red_Player_Ani);
        map[preBluePosition.x + 7, preBluePosition.y + 7] = 1; // 맵배열 에 초기위치 설정
        map[preRedPosition.x + 7, preRedPosition.y + 7] = 1;
    }

    //이동 가능 칸 표시
    void wayToGo(Vector3Int Position){
        for (int x = Position.x + 6; x <= Position.x + 8; x++)
        {
            for (int y = Position.y + 6; y <= Position.y + 8; y++)
            {
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x-7, y-7, 0), isBlueTurn ? blue_PTile : red_PTile);
                }
            }
        }
    }

    //이동 가능 칸 초기화
    void resetZeroTile(Vector3Int Position)
    {
        for (int x = Position.x + 6; x <= Position.x + 8; x++)
        {
            for (int y = Position.y + 6; y <= Position.y + 8; y++)
            {
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x - 7, y - 7, 0), null);
                }
            }
        }
    }
}
