using System;
namespace GameOfLife{
    class Cell{
        public bool IsAlive {get; set;}
        private int Neighbours;
        private int[] Index;

        public Cell(int[] index){
            this.IsAlive = false;
            this.Index = index;
            this.Neighbours = 0;
        }

        public void CountNeighbours(Cell[,] map){
        // Check all neighbouring cells
            this.Neighbours = 0;
            for(int row = -1; row <= 1; row++){
                for(int col = -1; col <= 1; col++){
                    // If not within map bounds
                    if(Index[0] + row >= map.GetLength(0) || Index[1] + col >= map.GetLength(1)
                    || Index[0] + row < 0 || Index[1] + col < 0){
                        continue;
                    }else if(row == 0 && col == 0){
                        continue;
                    }
                    else{
                        if(map[Index[0] + row,Index[1] +  col].IsAlive){
                        this.Neighbours++;
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        private void CheckRules(){
            switch(this.Neighbours){
                case int n when n < 2:
                    // Exposure (dies)
                    this.IsAlive = false;
                    break;
                case int n when n > 3:
                    // Overcrowding (dies)
                    this.IsAlive = false;
                    break;
                case 2:
                    // Unchanged to next generation (lives)
                    break;
                case 3:
                    // Unchanged to next generation (lives)
                    // Or if dead, repopulate
                    if (!this.IsAlive){
                        this.IsAlive = true;
                    }
                    break;
            }
        }

        private void Print(){
            if(this.IsAlive){
                Console.Write("■");
            }else{
                Console.Write("□");
            }
        }

        // To be called externally when next tick occurs
        public void Update(){
            Print();
            CheckRules();
        }
    }
}