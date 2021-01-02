/*
 * This file is part of the Trilateration package.
 *
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 *
 * @author Matias Gutierrez <soporte@tbmsp.net>
 * @file Trilateration.cs
 *
 * Project home:
 *   https://github.com/tbmsp/trilateration
 *
 */
using MathNet.Numerics.LinearAlgebra;
using System;

namespace TestRealTimeCharts { 
    class Trilateration{

        public static double[] Trilaterate2DLinear(double[] pA, double[] pB, double[] pC, double rA, double rB, double rC)
        {
            //Konwersja double na wektory
            Vector<double> vA = Vector<double>.Build.Dense(pA);
            Vector<double> vB = Vector<double>.Build.Dense(pB);
            Vector<double> vC = Vector<double>.Build.Dense(pC);

            //Deklaracja elementów b
            //bBA = 1/2 * (rA^2 - rB^2 + dBA^2)
            double[] b = { 0, 0 };
            b[0] = 0.5 * (Math.Pow(rA, 2) - Math.Pow(rB, 2) + Math.Pow(getDistance(pB, pA), 2));
            b[1] = 0.5 * (Math.Pow(rA, 2) - Math.Pow(rC, 2) + Math.Pow(getDistance(pC, pA), 2));
            //Konwersja listy b na wektor
            Vector<double> vb = Vector<double>.Build.Dense(b);

            //Budowa listy
            //A =   {x2 -x1, y2 - y1}
            //      {x3 - x1, y3 - y1}
            double[,] A = { { pB[0] - pA[0], pB[1] - pA[1] }, { pC[0] - pA[0], pC[1] - pA[1] } };
            //Konwersja mA na macierz
            Matrix<double> mA = Matrix<double>.Build.DenseOfArray(A);
            //Macierz transponowana
            Matrix<double> mAT = mA.Transpose();

            //Zadeklarowanie rozwiązania wektora x do 0
            Vector<double> x = Vector<double>.Build.Dense(2);

            //Sprawdzanie czy A*AT nie jest pojedyńcze 
            double det = mA.Multiply(mAT).Determinant();
            if (mA.Multiply(mAT).Determinant() > 0.1)
            {
                //x = ((AT * A)^-1)*AT*b
                // x = (((mA.Multiply(mAT)).Inverse()).Multiply(mAT)).Multiply(vb);

                x = (mA.Transpose() * mA).Inverse() * (mA.Transpose() * vb);
            }
            else
            {
                
                x = (((mA.Multiply(mAT)).Inverse()).Multiply(mAT)).Multiply(vb);
            }

            //Końcowa pozycja
            //return jako double
            return (x.Add(vA)).ToArray();
        }

        private static double getDistance(double[] p1, double[] p2)
        {
            //d^2 = (p1[0] - p2[0])^2 + (p1[1] - p2[1]);
            double distSquared = Math.Pow((p1[0] - p2[0]), 2) + Math.Pow((p1[1] - p2[1]), 2);
            return Math.Sqrt(distSquared);
        }
    }


}
