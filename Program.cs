using System.IO;

namespace GameOfLife{
    class Program{
        // Converts a jagged string array to a multidimensional int array
        static int[,] ConvertJaggedToMultiArray(string[][]? jagged){
            int x = jagged.Length;
            int y = jagged[0].Length;

            var result = new int[x, y];

            for (int i = 0; i < x; i++){
                for (int j = 0; j < y; j++){
                    result[i, j] = Convert.ToInt32(jagged[i][j]);
                }
            }
            return result;
        }

        static Simulation LoadFile(){
            string? dir = "";
            Simulation newSim;

            // Identify file in preset directory
            dir = Environment.CurrentDirectory + "/presets/";

            // Get preset directory   
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] files = di.GetFiles("*.csv");
            // Write presets to console
            foreach(FileInfo f in files){
                Console.WriteLine(String.Join("\n", Path.GetFileNameWithoutExtension(f.Name)));
            }

            // Get user response
            Console.WriteLine("Enter file to load: ");
            dir += Console.ReadLine() + ".csv";

            // Read selected file to jagged array
            var completeFile = File.ReadLines(dir).Select(x => x.Split(',')).ToArray();

            var convertedFile = ConvertJaggedToMultiArray(completeFile);
            newSim = new Simulation(convertedFile);

            return newSim;
        }
        static void Main(string[] args){
            Simulation s = LoadFile();
            
            // complete maximum 2000 iterations
            int i = 0;
            while(i < 2000){
                Console.Clear();
                s.Tick();
                i++;     
            }            
        }
    }
}