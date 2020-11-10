using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Grafos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery]int source)
        {
            //Matriz setada na mão
            //int[,] graph =  {
            //             { 0, 0, 0, 861, 0, 211, 0, 0, 0, 586, 0, 753, 382, 896, 0, 0, 0, 0, 0, 0 },
            //             { 0, 0, 423, 617, 365, 0, 0, 0, 0, 357, 0, 0, 806, 0, 0, 0, 0, 0, 0, 0 },
            //             { 0, 423, 0, 554, 359, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 861, 617, 554, 0, 0, 0, 0, 0, 0, 656, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 0, 365, 359, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 211, 0, 0, 0, 0, 0, 988, 0, 293, 102, 0, 870, 399, 0, 0, 0, 0, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 988, 0, 228, 43, 0, 573, 663, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 0, 228, 0, 801, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 293, 43, 801, 0, 724, 927, 936, 0, 0, 696, 0, 0, 0, 0, 0 },
            //             { 586, 357, 306, 656, 0, 102, 0, 0, 724, 0, 0, 736, 672, 804, 0, 0, 0, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //             { 753, 0, 0, 0, 0, 870, 663, 0, 936, 736, 634, 0, 844, 71, 798, 0, 713, 0, 0, 0 },
            //             { 382, 806, 0, 0, 0, 399, 0, 0, 0, 672, 0, 844, 0, 21, 0, 299, 0, 0, 0, 0 },
            //             { 896, 0, 0, 0, 0, 0, 0, 0, 0, 804, 0, 71, 21, 0, 244, 447, 726, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 696, 0, 927, 798, 0, 244, 0, 0, 387, 0, 0, 0 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 299, 447, 0, 0, 503, 113, 431, 0 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 713, 0, 726, 387, 503, 0, 916, 490, 0 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 113, 916, 0, 980, 326 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 431, 490, 980, 0, 455 },
            //             { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 455, 0 }
            //                };

            //return DijkstraAlgo(graph, source, 20);

            int[,] graph =  {
                         { 0, cst, cst, 861, cst, 211, cst, cst, cst, 586, cst, 753, 382, 896, cst, cst, cst, cst, cst, cst},
                         { cst, 0, 423, 617, 365, cst, cst, cst, cst, 357, cst, cst, 806, cst, cst, cst, cst, cst, cst, cst},
                         { cst, 423, 0, 554, 359, cst, cst, cst, cst, 306, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst},
                         { 861, 617, 554, 0, cst, cst, cst, cst, cst, 656, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst},
                         { cst, 365, 359, cst, 0, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst},
                         { 211, cst, cst, cst, cst, 0, 988, cst, 293, 102, cst, 870, 399, cst, cst, cst, cst, cst, cst, cst},
                         { cst, cst, cst, cst, cst, 988, 0, 228, 43, cst, 573, 663, cst, cst, cst, cst, cst, cst, cst, cst},
                         { cst, cst, cst, cst, cst, cst, 228, 0, 801, cst, 31, cst, cst, cst, cst, cst, cst, cst, cst, cst},
                         { cst, cst, cst, cst, cst, 293, 43, 801, 0, 724, 927, 936, cst, cst, 696, cst, cst, cst, cst, cst},
                         { 586, 357, 306, 656, cst, 102, cst, cst, 724, 0, cst, 736, 672, 804, cst, cst, cst, cst, cst, cst},
                         { cst, cst, cst, cst, cst, cst, 573, 31, 927, cst, 0, 634, cst, cst, 927, cst, cst, cst, cst, cst},
                         { 753, cst, cst, cst, cst, 870, 663, cst, 936, 736, 634, 0, 844, 71, 798, cst, 713, cst, cst, cst },
                         { 382, 806, cst, cst, cst, 399, cst, cst, cst, 672, cst, 844, 0, 21, cst, 299, cst, cst, cst, cst },
                         { 896, cst, cst, cst, cst, cst, cst, cst, cst, 804, cst, 71, 21, 0, 244, 447, 726, cst, cst, cst },
                         { cst, cst, cst, cst, cst, cst, cst, cst, 696, cst, 927, 798, cst, 244, 0, cst, 387, cst, cst, cst },
                         { cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, 299, 447, cst, 0, 503, 113, 431, cst },
                         { cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, 713, 0, 726, 387, 503, 0, 916, 490, cst },
                         { cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, 113, 916, 0, 980, 326 },
                         { cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, 431, 490, 980, 0, 455 },
                         { cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, cst, 326, 455, 0 }
                            };

            return FloydWarshall(graph, 20);
        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public string Print(int[] distance, int verticesCount)
        {
            string returnStr;

            returnStr = "Vertex    Distance from source\n";

            for (int i = 0; i < verticesCount; ++i) {
                returnStr += string.Format("{0}\t  {1}\n", i, distance[i]);
            }

            return returnStr;
        }

        public string DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            return Print(distance, verticesCount);
        }

        public const int cst = 9999;

        private string Print(int[,] distance, int verticesCount)
        {
            string strReturn = "";
            strReturn += "Menor distancia entre cada par de vértices:\n\n";
            
            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == cst)
                        strReturn += string.Format("cst".PadLeft(4));
                    else
                        strReturn += string.Format(distance[i, j].ToString().PadLeft(7));
                }
                strReturn += "\n";
            }
            return strReturn;
        }

        public string FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                    distance[i, j] = graph[i, j];

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }

            return Print(distance, verticesCount);
        }


    }
}
