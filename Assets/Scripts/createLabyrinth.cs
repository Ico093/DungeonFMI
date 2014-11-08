
using UnityEngine;

using System.Collections;

using System.Collections.Generic;



public class createLabyrinth : MonoBehaviour
	
{
	public int height;
	public int width;
	private int[,] maze;
	public int[] start=new int[2];
	public int[] end=new int[2];
	public GameObject labyrinth_wall;
	public GameObject bonus1;
	public GameObject player=null;

	void Start() {
		player=GameObject.Find("player");
		maze = new int[height,width];
		maze = generateMaze ();
		for (int i=0; i<height; i++) {
			for (int j=0; j<width; j++)
				if (maze[i,j]==1) Instantiate(labyrinth_wall,new Vector3(i*2,j*2,0),Quaternion.identity);
				else if (maze[i,j]==2)Instantiate(bonus1,new Vector3(i*2,j*2,0),Quaternion.identity);

				}


	}
	public int[,] generateMaze() {

		// Initialize
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++)
				maze[i,j] = 1;
		// r for row、c for column
		// Generate random r
		int r = Random.Range(1,height);
		while (r % 2 == 0) {
			r = Random.Range(1,height);
		}
		// Generate random c
		int c = Random.Range(1,width);
		while (c % 2 == 0) {
			c = Random.Range(1,width);
		}

		// Starting cell
		var functions = player.GetComponent<LabyrinthMove> ();
		functions.setTransform (r, c);
		maze[r,c] = 0;

		
		//　Allocate the maze with recursive method
		recursion(r, c);
		
		return maze;
	}
	
	public void recursion(int r, int c) {
		// 4 random directions
		int[] randDirs = generateRandomDirections();
		// Examine each direction
		for (int i = 0; i < randDirs.Length; i++) {
			
			switch(randDirs[i]){
			case 1: // Up
				//　Whether 2 cells up is out or not
				if (r - 2 <= 0)
					continue;
				if (maze[r - 2,c] != 0) {
					if (Random.Range(1,100)>80) 
						maze[r-2,c] = 2;
					else 
						maze[r-2,c] = 0;
					if (Random.Range(1,100)>80) 
						maze[r-1,c] = 2;
					else 
						maze[r-1,c] = 0;
					recursion(r - 2, c);
				}
				break;
			case 2: // Right
				// Whether 2 cells to the right is out or not
				if (c + 2 >= width - 1)
					continue;
				if (maze[r,c + 2] != 0) {
					maze[r,c + 2] = 0;
					maze[r,c + 1] = 0;
					recursion(r, c + 2);
				}
				break;
			case 3: // Down
				// Whether 2 cells down is out or not
				if (r + 2 >= height - 1)
					continue;
				if (maze[r + 2,c] != 0) {
					maze[r+2,c] = 0;
					maze[r+1,c] = 0;
					recursion(r + 2, c);
				}
				break;
			case 4: // Left
				// Whether 2 cells to the left is out or not
				if (c - 2 <= 0)
					continue;
				if (maze[r,c - 2] != 0) {
					maze[r,c - 2] = 0;
					maze[r,c - 1] = 0;
					recursion(r, c - 2);
				}
				break;
			}
		}
		
	}
	
	/**
 * Generate an array with random directions 1-4
 * @return Array containing 4 directions in random order
 */
	public int[] generateRandomDirections() {
		int[] randoms;
		randoms = new int[5];
		for (int i = 0; i < 4; i++)
			randoms[i]=i+1;
		randoms=Shuffle (randoms);
		
		return randoms;
	}

	public int[] Shuffle(int[] list)  
	{  
		int n = list.Length;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(1,n + 1);  
			int value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
		return list;
	}
}