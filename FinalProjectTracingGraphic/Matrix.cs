using System;
using System.Collections.Generic;
using System.Collections;

namespace FinalProjectTracingGraphic
{
    public class Matrix
    {
        private double[,] matrixContent;

        public Matrix(double[,] content)
        {
            matrixContent = content;
        }
        public double this[int y,int x]
        {
            get
            {
                return matrixContent[y,x];
            }
            set
            {
                matrixContent[y, x] = value;
            }
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.matrixContent.GetLength(1) == b.matrixContent.GetLength(0))
            {
                int iterationLength = a.matrixContent.GetLength(1);
                Matrix m = new Matrix(new double[a.matrixContent.GetLength(0), b.matrixContent.GetLength(1)]);
                for (int y = 0; y < m.matrixContent.GetLength(0); y++)
                {
                    for (int x = 0; x < m.matrixContent.GetLength(1); x++)
                    {
                        m[y, x] = 0;
                        for (int i = 0; i < iterationLength; i++)
                        {
                            m[y, x] += a.matrixContent[y, i] * b[i, x];
                        }
                    }
                }
                return m;
            }
            else
            {
                return null;
            }
        }
    }
}
