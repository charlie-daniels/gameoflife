namespace GameOfLife{
    class Simulation{
        Cell[,] Map;

        // Perform game tick
        public void Tick(){
            foreach(Cell c in Map){
                c.CountNeighbours(Map);
            }
            for(int i = 0; i < Map.GetLength(0); i++){
                for(int k = 0; k < Map.GetLength(1); k++){
                    Map[i,k].Update();
                }
                // Seperate rows on commandline
                Console.WriteLine();
            }
            // Pause for 0.2s
            System.Threading.Thread.Sleep(200);
        }

        // Create map of dimensions x, y
        private void InitialiseMap(){
            for(int i = 0; i < Map.GetLength(0); i++){
                for(int k = 0; k < Map.GetLength(1); k++){
                    int[] index = {i,k};
                    Map[i,k] = new Cell(index);
                }
            }
        }

        // Map size of dimensions x, y
        public Simulation(int x, int y){
            Map = new Cell[y,x];
            InitialiseMap();
        }
    }
}