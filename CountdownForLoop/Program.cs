using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CountdownForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////////////
            // Hackerrank Test Case 1
            ////////////////////////////////////////////////////////////////////////////////
            //var scores_raw = "295 294 291 287 287 285 285 284 283 279 277 274 274 271 270 268 268 268 264 260 259 258 257 255 252 250 244 241 240 237 236 236 231 227 227 227 226 225 224 223 216 212 200 197 196 194 193 189 188 187 183 182 178 177 173 171 169 165 143 140 137 135 133 130 130 130 128 127 122 120 116 114 113 109 106 103 99 92 85 81 69 68 63 63 63 61 57 51 47 46 38 30 28 25 22 15 14 12 6 4";
            //string[] scores_temp = scores_raw.Split(' ');
            //int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);

            //var alice_raw = "5 5 6 14 19 20 23 25 29 29 30 30 32 37 38 38 38 41 41 44 45 45 47 59 59 62 63 65 67 69 70 72 72 76 79 82 83 90 91 92 93 98 98 100 100 102 103 105 106 107 109 112 115 118 118 121 122 122 123 125 125 125 127 128 131 131 133 134 139 140 141 143 144 144 144 144 147 150 152 155 156 160 164 164 165 165 166 168 169 170 171 172 173 174 174 180 184 187 187 188 194 197 197 197 198 201 202 202 207 208 211 212 212 214 217 219 219 220 220 223 225 227 228 229 229 233 235 235 236 242 242 245 246 252 253 253 257 257 260 261 266 266 268 269 271 271 275 276 281 282 283 284 285 287 289 289 295 296 298 300 300 301 304 306 308 309 310 316 318 318 324 326 329 329 329 330 330 332 337 337 341 341 349 351 351 354 356 357 366 369 377 379 380 382 391 391 394 396 396 400";
            //string[] alice_temp = alice_raw.Split(' ');
            //int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);

            ////////////////////////////////////////////////////////////////////////////////
            // HJR Test set 1
            ////////////////////////////////////////////////////////////////////////////////            
            Debug.WriteLine("-------------------------------------------------------------------");
            int[] scores = { 100, 100, 50, 40, 40, 20, 10 };

            int[] alice0 = { 5, 25, 50, 120 };
            int[] expectedResult0 = { 6, 4, 2, 1 };
            int[] alice1 = { 10, 20, 50, 120 };  
            int[] expectedResult1 = { 5, 4, 2, 1 };
            int[] alice2 = { 10, 20, 115, 120 };  
            int[] expectedResult2 = { 5, 4, 1, 1 };
            int[] alice3 = { 10, 20, 120, 120 }; 
            int[] expectedResult3 = { 5, 4, 1, 1 };
            int[] alice4 = { 2, 5, 100, 120 };   
            int[] expectedResult4 = { 6, 6, 1, 1 };
            int[] alice5 = { 2, 75, 75, 120 }; 
            int[] expectedResult5 = { 6, 2, 2, 1 };
            int[] alice6 = { 10, 30, 75, 75 };
            int[] expectedResult6 = { 5, 4, 2, 2 };

            int[][] aliceScoresArrayOfArrays = new int[][]
            {
                alice0, alice1, alice2, alice3, alice4, alice5, alice6
            };

            int[][] expectedResultsArrayOfArrays = new int[][]
            {
                expectedResult0, expectedResult1, expectedResult2, expectedResult3, expectedResult4, expectedResult5, expectedResult6
            };

            int count = 0;
            foreach (int[] aliceScoreArray in aliceScoresArrayOfArrays)
            {
                int[] result = ClimbingLeaderboard(scores, aliceScoreArray);
                var expectedResultsArray = expectedResultsArrayOfArrays[count];
                bool isEqual = Enumerable.SequenceEqual(result, expectedResultsArray);
                if (isEqual)
                    Debug.WriteLine(count + " Test passed");
                else
                {
                    Debug.WriteLine("**** " + count + " Test failed. Expected " + String.Join(" ", expectedResultsArray) + " but got " + String.Join(" ", result) + " ****");
                }                    
                count++;
            }
            Debug.WriteLine("-------------------------------------------------------------------");

        }

        private static int[] ClimbingLeaderboard(int[] otherPeoplesScores, int[] aliceScores)
        {
            var aliceScoreRanking = new List<int>();
            var scoresStartingIndex = 0;
            var nextScoreRanking = 1;
            var lastScoreRanking = 0;
            var lastScore = -1;
            var finalScoreRankingFound = false;

            for (int count = aliceScores.Length - 1; count > -1; count--)
            {
                var aliceScore = aliceScores[count];
                //Debug.WriteLine("---------------------------------------");
                //Debug.WriteLine(count + ": Alice score " + aliceScore);

                if (aliceScore == lastScore)
                {
                    aliceScoreRanking.Add(lastScoreRanking);
                    continue;
                }

                lastScore = aliceScore;

                var score = otherPeoplesScores[scoresStartingIndex];

                if (aliceScore > score)
                {
                    // Populate Alice score ranking list
                    aliceScoreRanking.Add(nextScoreRanking);
                    lastScoreRanking = nextScoreRanking;

                    // Find next valid index (i.e. scoresStartingIndex)
                    if (scoresStartingIndex != 0)
                    {
                        scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);
                        // Increase nextScoreRanking 
                        nextScoreRanking++;
                    }
                }
                else if (aliceScore < score)
                {
                    // See if we're at the end of the list of other's scores
                    var nextUniqueScoreIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);
                    if (nextUniqueScoreIndex == -1)
                    {
                        nextScoreRanking++;
                        aliceScoreRanking.Add(nextScoreRanking);
                        lastScoreRanking = nextScoreRanking;
                        break;
                    }

                    //We now know the current aliceScore is less than the score at this index, so we can increase nextScoreRanking to reflect this
                    if (!finalScoreRankingFound)
                    {
                        nextScoreRanking++;
                    }

                    // Prepare to look at the next unique score
                    scoresStartingIndex = nextUniqueScoreIndex;
                    if (scoresStartingIndex == -1)
                    {
                        nextScoreRanking++;
                        aliceScoreRanking.Add(nextScoreRanking);
                        lastScoreRanking = nextScoreRanking;
                        break;
                    }

                    // Deal with the situation where we're at the end of the Alice score's array, or the final score will not be ranked
                    if (count == 0)
                    {
                        CountZeroEndGame(otherPeoplesScores, aliceScoreRanking, scoresStartingIndex, ref nextScoreRanking, aliceScore, ref score, ref lastScoreRanking, finalScoreRankingFound);
                    }
                    else
                        FindNextImportantScore(otherPeoplesScores, ref scoresStartingIndex, aliceScore, ref aliceScoreRanking, ref nextScoreRanking, count, ref finalScoreRankingFound, ref lastScoreRanking);
                }
                else
                {
                    // Scores are equal

                    // Populate Alice score ranking list
                    aliceScoreRanking.Add(nextScoreRanking);
                    lastScoreRanking = nextScoreRanking;

                    // Find next valid index (i.e. scoresStartingIndex)
                    scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);

                    // Increase nextScoreRanking 
                    nextScoreRanking++;
                }

                //Debug.WriteLine(String.Join("\n", aliceScoreRanking));
            }
            //Debug.WriteLine("---------------------------------------");
            //Debug.WriteLine(String.Join("\n", aliceScoreRanking));

            // Reverse the order of the aliceScoreRanking list
            aliceScoreRanking.Reverse();
            var aliceScoreRankingArray = aliceScoreRanking.ToArray();
            return aliceScoreRankingArray;
        }

        private static void CountZeroEndGame(int[] otherPeoplesScores, List<int> aliceScoreRanking, int scoresStartingIndex, ref int nextScoreRanking, int aliceScore, ref int score, ref int lastScoreRanking, bool finalScoreRankingFound)
        {
            for (int othersScoreIndex = scoresStartingIndex; othersScoreIndex < otherPeoplesScores.Length; othersScoreIndex++)
            {
                score = otherPeoplesScores[othersScoreIndex];
                if (aliceScore >= score)
                {
                    aliceScoreRanking.Add(nextScoreRanking);
                    lastScoreRanking = nextScoreRanking;
                    break;
                }
                else
                {
                    var nextUniqueOthersScoreIndex = FindNextUniqueScoreIndex(othersScoreIndex, otherPeoplesScores);
                    if (nextUniqueOthersScoreIndex == - 1)
                    {
                        if (finalScoreRankingFound)
                            aliceScoreRanking.Add(nextScoreRanking);
                        else
                            aliceScoreRanking.Add(nextScoreRanking +1);
                        break;
                    }

                    if (nextUniqueOthersScoreIndex == othersScoreIndex + 1)
                    {
                        //hjr
                       nextScoreRanking++;
                    }
                }
            }
        }

        private static void FindNextImportantScore(int[] otherPeoplesScores, ref int scoresStartingIndex, int aliceScore, ref List<int> aliceScoreRanking, ref int nextScoreRanking, int count, ref bool finalScoreRankingFound, ref int lastScoreRanking)
        {
            var score = otherPeoplesScores[scoresStartingIndex];

            if (aliceScore > score)
            {
                // Populate Alice score ranking list
                aliceScoreRanking.Add(nextScoreRanking);
                lastScoreRanking = nextScoreRanking;

                // Find next valid index (i.e. scoresStartingIndex)
                scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);

                // Increase nextScoreRanking 
                nextScoreRanking++;
            }
            else if (aliceScore < score)
            {
                // The aliceScore is less than the current score so we can increase nextScoreRanking 
                nextScoreRanking++;

                //Start actions to prepare for the next unique score
                scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);
             
                //if (count != -1)
                //{
                for (int othersScoreIndex = scoresStartingIndex; othersScoreIndex < otherPeoplesScores.Length; othersScoreIndex++)
                {
                    score = otherPeoplesScores[othersScoreIndex];
                    if (aliceScore >= score)
                    {
                        aliceScoreRanking.Add(nextScoreRanking);
                        lastScoreRanking = nextScoreRanking;
                        scoresStartingIndex = othersScoreIndex;
                        break;
                    }
                    else
                    {
                        var nextUniqueScoreIndex = FindNextUniqueScoreIndex(othersScoreIndex, otherPeoplesScores);
                        if (nextUniqueScoreIndex == -1)
                        {
                            nextScoreRanking++;
                            aliceScoreRanking.Add(nextScoreRanking);
                            lastScoreRanking = nextScoreRanking;
                            finalScoreRankingFound = true;
                            break;
                        }
                                
                        if (nextUniqueScoreIndex == othersScoreIndex + 1)
                        {
                            nextScoreRanking++;
                        }                            
                    }
                }                
            }
            else
            {
                // Scores are equal

                // Populate Alice score ranking list
                aliceScoreRanking.Add(nextScoreRanking);
                lastScoreRanking = nextScoreRanking;

                // Find next valid index (i.e. scoresStartingIndex)
                scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);

                // Increase nextScoreRanking 
                nextScoreRanking++;
            }
        }

        private static int FindNextUniqueScoreIndex(int lastIndexUsed, int[] otherPeoplesScores)
        {
            var lastScore = otherPeoplesScores[lastIndexUsed];
            var index = lastIndexUsed;
            while (true)
            {
                if (!(otherPeoplesScores[index] == lastScore))
                {
                    break;
                }
                index++;

                // Deal with the situation where we have no more scores to inspect.
                // TODO deal with this 
                if (index == otherPeoplesScores.Length)
                    return -1;
            }

            // We've found a new unique value - pass it back
            return index;
        }


    }
}
