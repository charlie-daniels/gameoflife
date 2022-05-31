namespace GameOfLife{
    class Program{
        static void Main(string[] args){
            Simulation s = new Simulation(50, 25);

            int iteration = 0;
            while(iteration < 2000){
                Console.Clear();
                s.Tick();
                iteration++;
            }            
        }
    }
}