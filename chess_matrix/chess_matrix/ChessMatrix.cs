namespace chess_matrix
{
    public class ChessMatrix
    {
        public static int[][] CreateMatrix(int n)
        {
            var matrix = new int[n][];
            for (var r = 0; r < matrix.Length; r++)
            {
                matrix[r] = new int[n];
            }

            FillMatrix(matrix);
            return matrix;
        }

        public static void FillMatrix(int[][] matrix)
        {
            for (var r = 0; r < matrix.Length; r++)
            {
                for (var c = 0; c < matrix[r].Length; c++)
                {
                    matrix[r][c] = (c + r % 2) % 2;
                }
            }
        }
    }
}