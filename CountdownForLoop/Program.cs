using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CountdownForLoop
{
    class Program
    {
        private static void FileGame()
        {
            Debug.WriteLine("TEST");
            string text_raw = System.IO.File.ReadAllText(@"C:\temp\datafile.txt");
            //Debug.WriteLine(text_raw);
            string[] scores_temp = text_raw.Split(' ');
            int[] scoresIntArray = Array.ConvertAll(scores_temp, Int32.Parse);
            Debug.WriteLine("-------------------------------------------------------------------");

        }
        static void Main(string[] args)
        {
            FileGame();

            ////////////////////////////////////////////////////////////////////////////////

            // Select which tests to run
            //var runHackerRankTC1 = true;
            //var runHackerRankTC1Subset = true;
            //var runHJRTestSet1 = true;
            //var runHJRTestSet2 = true;

            var runHackerRankTC1 = false;
            var runHackerRankTC1Subset = false;
            var runHJRTestSet1 = false;
            var runHJRTestSet2 = false;

            ////////////////////////////////////////////////////////////////////////////////

            var testsAllPassed = true;
            var numberOfTestSetsRun = 0;
            
            ////////////////////////////////////////////////////////////////////////////////
            // Hackerrank Test Case 1
            ////////////////////////////////////////////////////////////////////////////////

            Debug.WriteLine("-------------------------------------------------------------------");
            Debug.WriteLine("Hackerrank Test Case 1");
            var scores_raw = "295 294 291 287 287 285 285 284 283 279 277 274 274 271 270 268 268 268 264 260 259 258 257 255 252 250 244 241 240 237 236 236 231 227 227 227 226 225 224 223 216 212 200 197 196 194 193 189 188 187 183 182 178 177 173 171 169 165 143 140 137 135 133 130 130 130 128 127 122 120 116 114 113 109 106 103 99 92 85 81 69 68 63 63 63 61 57 51 47 46 38 30 28 25 22 15 14 12 6 4";
            string[] scores_temp = scores_raw.Split(' ');
            int[] scoresTC1 = Array.ConvertAll(scores_temp, Int32.Parse);

            var alice_raw = "5 5 6 14 19 20 23 25 29 29 30 30 32 37 38 38 38 41 41 44 45 45 47 59 59 62 63 65 67 69 70 72 72 76 79 82 83 90 91 92 93 98 98 100 100 102 103 105 106 107 109 112 115 118 118 121 122 122 123 125 125 125 127 128 131 131 133 134 139 140 141 143 144 144 144 144 147 150 152 155 156 160 164 164 165 165 166 168 169 170 171 172 173 174 174 180 184 187 187 188 194 197 197 197 198 201 202 202 207 208 211 212 212 214 217 219 219 220 220 223 225 227 228 229 229 233 235 235 236 242 242 245 246 252 253 253 257 257 260 261 266 266 268 269 271 271 275 276 281 282 283 284 285 287 289 289 295 296 298 300 300 301 304 306 308 309 310 316 318 318 324 326 329 329 329 330 330 332 337 337 341 341 349 351 351 354 356 357 366 369 377 379 380 382 391 391 394 396 396 400";
            string[] alice_temp = alice_raw.Split(' ');
            int[] aliceTC1 = Array.ConvertAll(alice_temp, Int32.Parse);

            var expectedResult_raw = "88 88 87 85 84 84 83 82 81 81 80 80 80 80 79 79 79 79 79 79 79 79 77 75 75 74 73 73 73 71 71 71 71 71 71 70 70 69 69 68 68 68 68 67 67 67 66 66 65 65 64 64 62 61 61 60 59 59 59 59 59 59 58 57 56 56 55 55 53 52 52 51 51 51 51 51 51 51 51 51 51 51 51 51 50 50 50 50 49 49 48 48 47 47 47 45 43 42 42 41 38 36 36 36 36 35 35 35 35 35 35 34 34 34 33 33 33 33 33 32 30 28 28 28 28 27 27 27 26 23 23 22 22 20 20 20 18 18 15 15 14 14 13 13 11 11 10 10 8 8 7 6 5 4 4 4 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1";
            string[] expectedResult_temp = expectedResult_raw.Split(' ');
            int[] expectedResultTC1 = Array.ConvertAll(expectedResult_temp, Int32.Parse);

            int[][] aliceScoresArrayOfArraysTC1 = new int[][]
            {
                aliceTC1
            };

            int[][] expectedResultsArrayOfArraysTC1 = new int[][]
            {
                expectedResultTC1
            };

            var runSuccessTC1 = false;
            if (runHackerRankTC1)
            {
                runSuccessTC1 = RunTests(scoresTC1, aliceScoresArrayOfArraysTC1, expectedResultsArrayOfArraysTC1);
                if (!runSuccessTC1)
                    testsAllPassed = false;
            }          

            ////////////////////////////////////////////////////////////////////////////////
            // Hackerrank Test Case 1 subset
            ////////////////////////////////////////////////////////////////////////////////

            Debug.WriteLine("-------------------------------------------------------------------");
            Debug.WriteLine("Hackerrank Test Case 1S");
            
            // ranking                                                                         13
            //index                                                                    13      15                                                                     33
            var scores_rawTC1S = "295 294 291 287 287 285 285 284 283 279 277 274 274 271 270 268 268 268 264 260 259 258 257 255 252 250 244 241 240 237 236 236 231 227 227 227 226 225 224 223 216 212 200 197 196 194 193 189 188 187 183 182 178 177 173 171 169 165 143 140 137 135 133 130 130 130 128 127 122 120 116 114 113 109 106 103 99 92 85 81 69 68 63 63 63 61 57 51 47 46 38 30 28 25 22 15 14 12 6 4";
            string[] scores_tempTC1S = scores_rawTC1S.Split(' ');
            int[] scoresTC1S = Array.ConvertAll(scores_tempTC1S, Int32.Parse);

            var alice_rawTC1S = "227 228 229 229 233 235 235 236 242 242 245 246 252 253 253 257 257 260 261 266 266 268 269 271 271 275 276 281 282 283 284 285 287 289 289";
            string[] alice_tempTC1S = alice_rawTC1S.Split(' ');
            int[] aliceTC1S = Array.ConvertAll(alice_tempTC1S, Int32.Parse);

            var expectedResult_rawTC1S = "28 28 28 28 27 27 27 26 23 23 22 22 20 20 20 18 18 15 15 14 14 13 13 11 11 10 10 8 8 7 6 5 4 4 4";
            string[] expectedResult_tempTC1S = expectedResult_rawTC1S.Split(' ');
            int[] expectedResultTC1S = Array.ConvertAll(expectedResult_tempTC1S, Int32.Parse);

            int[][] aliceScoresArrayOfArraysTC1S = new int[][]
            {
                aliceTC1S
            };

            int[][] expectedResultsArrayOfArraysTC1S = new int[][]
            {
                expectedResultTC1S
            };

            var runSuccessTC1S = false;
            if (runHackerRankTC1Subset)
            {
                numberOfTestSetsRun++;
                runSuccessTC1S = RunTests(scoresTC1S, aliceScoresArrayOfArraysTC1S, expectedResultsArrayOfArraysTC1S);
                if (!runSuccessTC1S)
                    testsAllPassed = false;
            }          

            ////////////////////////////////////////////////////////////////////////////////
            // HJR Test set 1
            ////////////////////////////////////////////////////////////////////////////////     
            
            Debug.WriteLine("-------------------------------------------------------------------");
            Debug.WriteLine("HJR Test Set 1");
            int[] scoresHJR = { 100, 100, 50, 40, 40, 20, 10 };

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
            int[] alice7 = { 2, 3, 10, 30, 75, 75, 100 };
            int[] expectedResult7 = { 6, 6, 5, 4, 2, 2, 1 };

            int[][] aliceScoresArrayOfArraysHJRTestSet1 = new int[][]
            {
                alice0, alice1, alice2, alice3, alice4, alice5, alice6, alice7
            };            

            int[][] expectedResultsArrayOfArraysHJRTestSet1 = new int[][]
            {
                expectedResult0, expectedResult1, expectedResult2, expectedResult3, expectedResult4, expectedResult5, expectedResult6, expectedResult7
            };

            var runSuccessHJRTestSet1 = false;
            if (runHJRTestSet1)
            {
                numberOfTestSetsRun++;
                runSuccessHJRTestSet1 = RunTests(scoresHJR, aliceScoresArrayOfArraysHJRTestSet1, expectedResultsArrayOfArraysHJRTestSet1);
                if (!runSuccessHJRTestSet1)
                    testsAllPassed = false;
            }

            ////////////////////////////////////////////////////////////////////////////////
            // HJR Test set 2
            //////////////////////////////////////////////////////////////////////////////// 

            Debug.WriteLine("-------------------------------------------------------------------");
            Debug.Write("HJR Test Set 2");
            if (!runHJRTestSet2)
                Debug.Write(" - not run \n");
            else
                Debug.Write("\n");

            int[] scoresHJRTS2 = { 100, 100, 50, 40, 40, 20, 10 };
            int[] aliceHJRTS2 = { 1, 2, 3, 4, 5 };          
            int[] expectedResultHJRTS2 = { 6, 6, 6, 6, 6 };

            int[][] aliceScoresArrayOfArraysHJRTestSet2 = new int[][]
            {
               aliceHJRTS2
            };
            int[][] expectedResultsArrayOfArraysHJRTestSet2 = new int[][]
            {
                expectedResultHJRTS2
            };

            var runSuccessHJRTS2 = false;
            if (runHJRTestSet2)
            {
                numberOfTestSetsRun++;
                runSuccessHJRTS2 = RunTests(scoresHJRTS2, aliceScoresArrayOfArraysHJRTestSet2, expectedResultsArrayOfArraysHJRTestSet2);

                if (!runSuccessHJRTS2)
                    testsAllPassed = false;
            }

            //////////////////////////////////////////////////////////////////////////////// 

            // Summarise

            if (!testsAllPassed)
            {
                Debug.WriteLine("*********************************************************************");
                Debug.WriteLine("********************** There are test failures ********************** ");
                Debug.WriteLine("*********************************************************************");
            }
            else
            {
                if (numberOfTestSetsRun > 0)
                {
                    Debug.WriteLine("-------------------------------------------------------------------");
                    Debug.WriteLine(numberOfTestSetsRun + " tests run. All tests passed ok");
                    Debug.WriteLine("-------------------------------------------------------------------");
                }
                else
                {
                    Debug.WriteLine("-------------------------------------------------------------------");
                    Debug.WriteLine("No tests run");
                    Debug.WriteLine("-------------------------------------------------------------------");
                }
                
            }             
        }

        private static bool RunTests(int[] scores, int[][] aliceScoresArrayOfArrays, int[][] expectedResultsArrayOfArrays)
        {
            bool testPassed = false;
            int count = 0;
            foreach (int[] aliceScoreArray in aliceScoresArrayOfArrays)
            {
                int[] result = climbingLeaderboard(scores, aliceScoreArray);
                var expectedResultsArray = expectedResultsArrayOfArrays[count];
                bool isEqual = Enumerable.SequenceEqual(result, expectedResultsArray);
                if (isEqual)
                {
                    Debug.WriteLine("Test index: " + count + " - Test passed");
                    testPassed = true;
                }
                   
                else
                {
                    Debug.WriteLine("**** " + count + " Test failed. Expected \n" + String.Join(" ", expectedResultsArray) + "\n" + String.Join(" ", result) + " ****");
                }
                count++;
            }
            return testPassed;
        }

        private static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var aliceScoreRanking = new List<int>();
            var scoresStartingIndex = 0;
            var nextScoreRanking = 1;
            var lastScoreRanking = 0;
            var lastScore = -1;
            var finalScoreRankingFound = false;

            for (int count = alice.Length - 1; count > -1; count--)
            {
                var aliceScore = alice[count];
                //Debug.WriteLine("---------------------------------------");
                //Debug.WriteLine(count + ": Alice score " + aliceScore);

                if (aliceScore == lastScore)
                {
                    aliceScoreRanking.Add(lastScoreRanking);
                    continue;
                }

                lastScore = aliceScore;

                if (scoresStartingIndex == -1)
                {
                    aliceScoreRanking.Add(nextScoreRanking);
                    continue;
                }

                var score = scores[scoresStartingIndex];

                if (aliceScore > score)
                {
                    // Populate Alice score ranking list
                    aliceScoreRanking.Add(nextScoreRanking);
                    lastScoreRanking = nextScoreRanking;

                    // Find next valid index (i.e. scoresStartingIndex)
                    if (scoresStartingIndex != 0 && count > 0)
                    {

                        var nextAliceScore = alice[count -1];
                        if (!(nextAliceScore >= score))
                        {
                            scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, scores);
                            // Increase nextScoreRanking 
                            nextScoreRanking++;
                        }                            
                    }
                }
                else if (aliceScore < score)
                {
                    // See if we're at the end of the list of other's scores
                    var nextUniqueScoreIndex = FindNextUniqueScoreIndex(scoresStartingIndex, scores);
                    if (nextUniqueScoreIndex == -1 && count == 0)
                    {
                        nextScoreRanking++;
                        aliceScoreRanking.Add(nextScoreRanking);
                        lastScoreRanking = nextScoreRanking;
                        break;
                    }
                    else if (nextUniqueScoreIndex == -1 && count > 0)
                    {
                        aliceScoreRanking.Add(nextScoreRanking);
                        FindNextImportantScore(ref alice, scores, ref scoresStartingIndex, aliceScore, ref aliceScoreRanking, ref nextScoreRanking, count, ref finalScoreRankingFound, ref lastScoreRanking);
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
                        if (!finalScoreRankingFound)
                            nextScoreRanking++;
                        aliceScoreRanking.Add(nextScoreRanking);
                        lastScoreRanking = nextScoreRanking;
                        break;
                    }

                    // Deal with the situation where we're at the end of the Alice score's array, or the final score will not be ranked
                    if (count == 0)
                    {
                        CountZeroEndGame(scores, aliceScoreRanking, scoresStartingIndex, ref nextScoreRanking, aliceScore, ref score, ref lastScoreRanking, finalScoreRankingFound);
                    }
                    else
                        FindNextImportantScore(ref alice, scores, ref scoresStartingIndex, aliceScore, ref aliceScoreRanking, ref nextScoreRanking, count, ref finalScoreRankingFound, ref lastScoreRanking);
                }
                else
                {
                    // Scores are equal

                    // Populate Alice score ranking list
                    aliceScoreRanking.Add(nextScoreRanking);
                    lastScoreRanking = nextScoreRanking;

                    // Find next valid index (i.e. scoresStartingIndex)
                    scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, scores);

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
                       nextScoreRanking++;
                    }
                }
            }
        }

        private static void FindNextImportantScore(ref int[]alice, int[] otherPeoplesScores, ref int scoresStartingIndex, int aliceScore, ref List<int> aliceScoreRanking, ref int nextScoreRanking, int count, ref bool finalOtherPeoplesScoreFound, ref int lastScoreRanking)
        {
            var score = otherPeoplesScores[scoresStartingIndex];

            if (aliceScore > score)
            {
                // Populate Alice score ranking list
                aliceScoreRanking.Add(nextScoreRanking);
                lastScoreRanking = nextScoreRanking;

                var nextAliceScore = alice[count - 1];
                if (!(nextAliceScore >= score))
                {
                    // Find next valid index (i.e. scoresStartingIndex)
                    scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);

                    // Increase nextScoreRanking 
                    nextScoreRanking++;
                }
            }
            else if (aliceScore < score)
            {
                // The aliceScore is less than the current score so we can increase nextScoreRanking 
                if (!finalOtherPeoplesScoreFound)
                {
                    nextScoreRanking++;
                }
                

                //Start actions to prepare for the next unique score
                scoresStartingIndex = FindNextUniqueScoreIndex(scoresStartingIndex, otherPeoplesScores);
                if (scoresStartingIndex == -1)
                {
                    aliceScoreRanking.Add(nextScoreRanking);                   
                    return;
                }             
        
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
                            if (!finalOtherPeoplesScoreFound)
                                nextScoreRanking++;
                            aliceScoreRanking.Add(nextScoreRanking);
                            lastScoreRanking = nextScoreRanking;
                            finalOtherPeoplesScoreFound = true;
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
