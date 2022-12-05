using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterControlling : MonoBehaviour
{
    [SerializeField] private PositionDisposer playerPos;
    [SerializeField] private ButtonOfIntaraction but;

    private Movement playerMovment;
    private Map map;
    private WorldClockSteps clock;
    private Vector2Int goal;
    private List<Vector2Int> path;
    private bool stopSteps = false;
    private StationInteractor stationForInteract = null;

    public static CharacterControlling instance;
    private void Awake()
    {
        if (instance != null)
            Debug.LogError("more than one such class on the Scene");
        instance = this;
    }
    private void Start()
    {
        map = Map.instance;
        clock = WorldClockSteps.instance;
        playerMovment = playerPos.GetComponent<Movement>();

        WorldClockSteps.State3 += ResearchePath;
    }

    private void ResearchePath()
    {
        stationForInteract = null;
        List<Vector2Int> V2i = playerPos.GetAroundCells();

        if (V2i.Contains(goal))
        {
            path = new List<Vector2Int>();
            path.Add(playerPos.GetMapPosition());
            path.Add(goal);

            StationInteractor newStation = PositionDisposer.AllPositions[goal].GetComponent<StationInteractor>();
            if (newStation != null)
            {
                stationForInteract = newStation;
            }
        }
        else if (goal == playerPos.GetMapPosition())
        {
            path = null;
        }
        else
        {
            path = PathSearcher.FindPath(playerPos.GetMapPosition(), goal, map.map, 250);
            if (!stopSteps)
            {
                playerMovment.SetNextCell(path[1]);
                clock.OneMoreStep();
            }
        }
        map.RenderPath(path);
    }

    public void OnCellDown(Vector2Int v)
    {
        if (goal == v)
            Interact();

        stopSteps = true;
        stationForInteract = null;

        List<Vector2Int> V2i = playerPos.GetAroundCells();

        if (V2i.Contains(v))
        {
            path = new List<Vector2Int>();
            path.Add(playerPos.GetMapPosition());
            path.Add(v);

            StationInteractor newStation = PositionDisposer.AllPositions[v].GetComponent<StationInteractor>();
            if (newStation != null)
            {
                stationForInteract = newStation;
            }

            goal = v;
        }
        else if (v == playerPos.GetMapPosition())
        {
            goal = playerPos.GetMapPosition();
            path = null;
        }
        else
        {
            path = PathSearcher.FindPath(playerPos.GetMapPosition(), v, map.map, 250);
            if (path != null)
            {
                if (goal == v)
                {
                    playerMovment.SetNextCell(path[1]);
                    clock.TryStep();
                    stopSteps = false;
                }
                goal = v;
            }
        }
        map.RenderPath(path);
    }
    public void Interact()
    {
        if (stationForInteract != null)
        {
            stationForInteract.Interact();
        }
    }
}