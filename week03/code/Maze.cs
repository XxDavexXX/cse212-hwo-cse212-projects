using System;
using System.Collections.Generic;
using System.Linq;

public class Maze {
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap) {
        _mazeMap = mazeMap;
    }

    public void MoveLeft() {
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][0]) {
            _currY--; // Move left means decreasing Y coordinate
            Console.WriteLine("Moved left.");
        } else {
            Console.WriteLine("Can't go left!");
        }
    }

    public void MoveRight() {
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][1]) {
            _currY++; // Move right means increasing Y coordinate
            Console.WriteLine("Moved right.");
        } else {
            Console.WriteLine("Can't go right!");
        }
    }

    public void MoveUp() {
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][2]) {
            _currX--; // Move up means decreasing X coordinate
            Console.WriteLine("Moved up.");
        } else {
            Console.WriteLine("Can't go up!");
        }
    }

    public void MoveDown() {
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][3]) {
            _currX++; // Move down means increasing X coordinate
            Console.WriteLine("Moved down.");
        } else {
            Console.WriteLine("Can't go down!");
        }
    }

    public void ShowStatus() {
        Console.WriteLine($"Current location (x={_currX}, y={_currY})");
    }
}