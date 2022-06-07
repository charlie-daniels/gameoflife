using System;
namespace GameOfLife{
    class Cell{
        public bool isAlive {get; set;} = false;
        public int[] index {get; init;}
        private int _neighbours {get; set;} = 0;

        public void CountNeighbours(Cell[,] map){
        // Check all neighbouring cells
            this._neighbours = 0;
            for(int row = -1; row <= 1; row++){
                for(int col = -1; col <= 1; col++){
                    // If not within map bounds
                    if(index[0] + row >= map.GetLength(0) || index[1] + col >= map.GetLength(1)
                    || index[0] + row < 0 || index[1] + col < 0){
                        continue;
                    }else if(row == 0 && col == 0){
                        continue;
                    }
                    else{
                        if(map[index[0] + row,index[1] +  col].isAlive){
                        this._neighbours++;
                        }
                    }
                }
            }
        }

        private void CheckRules(){
            switch(this._neighbours){
                case int n when n < 2:
                    // Exposure (dies)
                    this.isAlive = false;
                    break;
                case int n when n > 3:
                    // Overcrowding (dies)
                    this.isAlive = false;
                    break;
                case 2:
                    // Unchanged to next generation (lives)
                    break;
                case 3:
                    // Unchanged to next generation (lives)
                    // Or if dead, repopulate
                    if (!this.isAlive){
                        this.isAlive = true;
                    }
                    break;
            }
        }

        private void Print(){
            if(this.isAlive){
                Console.Write("⬛");
            }else{
                Console.Write("⬜");
            }
        }

        // To be called externally when next tick occurs
        public void Update(){
            Print();
            CheckRules();
        }

        public Cell(int[] index){
            this.index = index;
        }
    }
}