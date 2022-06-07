namespace GameOfLife{
    class Simulation{
        private Cell[,] _map;

        // Perform game tick
        public void Tick(){
            foreach(Cell c in _map){
                c.CountNeighbours(_map);
            }
            for(int i = 0; i < _map.GetLength(0); i++){
                for(int k = 0; k < _map.GetLength(1); k++){
                    _map[i,k].Update();
                }
                // Seperate rows on commandline
                Console.WriteLine();
            }
            // Pause for 0.1s
            System.Threading.Thread.Sleep(100);
        }

        // Create empty map of dimensions x, y
        private void InitEmptyMap(int x, int y){
            for(int i = 0; i < _map.GetLength(0); i++){
                for(int k = 0; k < _map.GetLength(1); k++){
                    int[] index = {i,k};
                    _map[i,k] = new Cell(index);
                }
            }
        }

        // Map from file of size of file
        private void InitMapFromArray(int[,] liveCells){
            InitEmptyMap(liveCells.GetLength(1), liveCells.GetLength(0));
            foreach(Cell c in _map){
                c.isAlive = Convert.ToBoolean(liveCells[c.index[0],c.index[1]]);
            }
        }

        // Map size of dimensions x, y
        public Simulation(int x, int y){
            _map = new Cell[y,x];
            InitEmptyMap(x, y);
        }

        // Map from file of size of file
        public Simulation(int[,] liveCells){
            int x = liveCells.GetLength(1);
            int y = liveCells.GetLength(0);
            _map = new Cell[y,x];
            InitMapFromArray(liveCells);            
        }
    }
}