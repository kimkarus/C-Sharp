using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;

namespace NalogUser.Classes.AnalysisData
{
    public class Spreading
    {
        private CommonValues cmnVal;
        private Functions functions;
        private Processing processing;
        private Core cr;
        public Spreading(Core Cr)
        {
            this.cr = Cr;
            cmnVal = new CommonValues(cr);
            functions = new Functions(cmnVal);
            processing = new Processing(cmnVal, functions);
        }
        public class CommonValues
        {
            private EnterValues enVal;
            private OutValues ouVal;
            private Core cr;
            
            public CommonValues(Core Cr)
            {
                this.cr = Cr;
                enVal = new EnterValues();
                ouVal = new OutValues();
            }
            public EnterValues EnVal { get { return enVal; } set { enVal = value; } }
            public OutValues OuVal { get { return ouVal; } set { ouVal = value; } }
            public Core Cr { get { return cr; } }
            //
            public class EnterValues
            {
                //Локально
                //Общие
                private int N = 1000;
                private int Ntb = 10;
                private int sumR = 12;
                private int NeedExper;
                private int frequencyE;
                private int frequencyT;
                private double step;
                private float Otkl = 0.005f;
                //Равномерное распределение
                private float IntL = 0.1f;
                private float IntR = 0.2f;
                //Нормальное распределение
                private float MatO_T = 0f;
                private float Sko_T = 1f;
                //Экспоненциальное
                private float Lya = 0.5f;
                //хи-квадрат
                private int V = 2;
                //Стьюдент
                private int K = 2;
                //Фишер
                private int K1 = 2;
                private int K2 = 4;
                //Логнормальное
                private float M = 4f;
                //
                private TypeSpreading typeSpreading;
                //Глобально
                public int _N { get { return N; } set { N = value; } }
                public int _Ntb { get { return Ntb; } set { Ntb = value; } }
                public int _sumR { get { return sumR; } set { sumR = value; } }
                public int _NeedExper { get { return NeedExper; } set { NeedExper = value; } }
                public int _FrequencyE { get { return frequencyE; } set { frequencyE = value; } }
                public int _FrequencyT { get { return frequencyT; } set { frequencyT = value; } }
                public double _Step { get { return step; } set { step = value; } }
                public float _Otkl { get { return Otkl; } set { Otkl = value; } }
                public float _MatO_T { get { return MatO_T; } set { MatO_T = value; } }
                public float _Sko_T { get { return Sko_T; } set { Sko_T = value; } }
                public float _IntL { get { return IntL; } set { IntL = value; } }
                public float _IntR { get { return IntR; } set { IntR = value; } }
                public float _Lya { get { return Lya; } set { Lya = value; } }
                public int _K { get { return K; } set { K = value; } }
                public int _K1 { get { return K1; } set { K1 = value; } }
                public int _K2 { get { return K2; } set { K2 = value; } }
                public int _V { get { return V; } set { V = value; } }
                public float _M { get { return M; } set { M = value; } }
                public enum TypeSpreading
                {
                    Random = 0,
                    Normal = 1,
                    Exponecial = 2,
                    Xi2 = 3,
                    Student = 4,
                    Fisher = 5,
                    Erlang = 6,
                    Logistical = 7,
                    Pareto = 8,
                    Lognormal = 9
                }
                public TypeSpreading _TypeSpreading
                {
                    get { return typeSpreading; }
                    set { typeSpreading = value; }
                }
                public void Perem()
                {

                }
            }
            public class OutValues
            {
                private string NameOfR = "";
                //
                private double[] arX1;
                private double[] arX2;
                private double[,] arTable;
                private DataTable dt;
                //
                private double MatO_T;
                private double Disp_T;
                private double Sko_T;
                private double Xi2_T;
                private double maxValue;
                private double minValue;
                //
                private double MatO;
                private double Disp;
                private double Sko;
                private double Xi2;
                //
                private double sumInt = 0;
                private int sumNi = 0;
                private double sumNi_T = 0;
                private double sumCha = 0;
                private double sumCha_T = 0;
                private double sumXi2 = 0;
                //
                private float maxfFR = 0f;
                //private Распределения.EnterValues enVal = new Распределения.EnterValues();
                //
                public double[] _arX1 { get { return arX1; } set { arX1 = value; } }
                public double[] _arX2 { get { return arX2; } set { arX2 = value; } }
                public double[,] _arTable { get { return arTable; } set { arTable = value; } }
                public DataTable _Dt { get { return dt; } set { dt = value; } }
                //
                public double _MatO_T { get { return MatO_T; } set { MatO_T = value; } }
                public double _Disp_T { get { return Disp_T; } set { Disp_T = value; } }
                public double _Sko_T { get { return Sko_T; } set { Sko_T = value; } }
                public double _Xi2_T { get { return Xi2_T; } set { Xi2_T = value; } }
                public double _MaxValue { get { return maxValue; } set { maxValue = value; } }
                public double _MinValue { get { return minValue; } set { minValue = value; } }
                //
                public double _MatO { get { return MatO; } set { MatO = value; } }
                public double _Disp { get { return Disp; } set { Disp = value; } }
                public double _Sko { get { return Sko; } set { Sko = value; } }
                public double _Xi2 { get { return Xi2; } set { Xi2 = value; } }
                //
                public double _sumInt { get { return sumInt; } set { sumInt = value; } }
                public int _sumNi { get { return sumNi; } set { sumNi = value; } }
                public double _sumNi_T { get { return sumNi_T; } set { sumNi_T = value; } }
                public double _sumCha { get { return sumCha; } set { sumCha = value; } }
                public double _sumCha_T { get { return sumCha_T; } set { sumCha_T = value; } }
                public double _sumXi2 { get { return sumXi2; } set { sumXi2 = value; } }
                //
                public string _NameOfR { get { return NameOfR; } set { NameOfR = value; } }
                public float _maxfFR { get { return maxfFR; } set { maxfFR = value; } }

            }
        }
        //
        public CommonValues CmnVal { get { return cmnVal; } set { cmnVal = value; } }
        public Processing Process { get { return processing; } }
        public Functions Function { get { return functions; } }
        //
        public class Functions
        {
            private CommonValues cmnVal;
            private Core cr;
            //
            private double[] arA;
            private double[] arGamma;
            public Functions(CommonValues CmnVal)
            {
                cr = CmnVal.Cr;
                this.cmnVal = CmnVal;
                arA = new double[cmnVal.EnVal._Ntb];
            }
            public void Gamma(double[] arChG, int nG)
            {
                arGamma = new double[nG];
                for (int i = 0; i < nG; i++)
                {
                    arGamma[i] = 1;
                    int G_shag = 1; // Изначальный шаг фактариала
                    int G_fakt = 1; //Величина фактариала
                    if ((arChG[i] - Math.Floor(arChG[i])) == 0)
                    {
                        for (int G_i = 1; G_i < (int)Math.Floor(arChG[i]); G_i++)
                        {
                            arGamma[i] *= G_i;
                        }
                    }
                    else
                    {
                        //если нет, то:
                        for (int G_i = 0; G_i < (int)Math.Floor(arChG[i] - 1.0); G_i++)
                        {
                            G_shag += 2;
                            G_fakt *= G_shag;
                        }
                        arGamma[i] = (Math.Sqrt(Math.PI) * (double)G_fakt) / Math.Pow(2.0, Math.Floor(arChG[i]));
                    }
                }
            }
            public int Fact(int N)
            {
                int fact = 1;
                return fact;
            }
            public double maxX(double[] arX)
            {
                double max = 0;
                double[] sortArX = new double[cmnVal.EnVal._N];
                for (int i = 0; i < cmnVal.EnVal._N; i++)
                {
                    if (arX[i] > max)
                    {
                        max = Math.Abs(arX[i]);
                    }
                }

                return max;
            }
            public double minX(double[] arX)
            {
                double min = 0;
                double[] sortArX = new double[cmnVal.EnVal._N];
                for (int i = 0; i < cmnVal.EnVal._N; i++)
                {
                    if (arX[i] < min)
                    {
                        min = arX[i];
                    }
                }
                return min;
            }
            public double maxXDt(DataTable dt, string col)
            {
                double max = 0;
                double min = 0;
                foreach (DataRow row in dt.Rows)
                {
                    double value1 = cr.AnalysData.returnNullDouble(row[col]);
                    double value2 = cr.AnalysData.returnNullDouble(row[col]);
                    if (value1 >= max) max = value1;
                    if (value2 <= min) min = value2;
                }
                cmnVal.OuVal._MaxValue = max;
                cmnVal.OuVal._MinValue = min;
                return max;
            }

            public double Abs(double Num)
            {
                double X;
                if (Num < 0)
                {
                    X = (-1) * Num;
                }
                else
                {
                    X = Num;
                }
                return X;
            }
            public double MatOX()
            {
                double sumX = 0.0;
                double mx = 0;
                for (int i = 0; i < cmnVal.EnVal._N; i++)
                {
                    sumX += cmnVal.OuVal._arX1[i];
                }
                mx = sumX / (double)cmnVal.EnVal._N;
                return mx;
            }
            public double DispX(double MatO)
            {
                double sumX2 = 0;
                double dx = 0.0;
                for (int i = 0; i < cmnVal.EnVal._N; i++)
                {
                    sumX2 += Math.Pow(cmnVal.OuVal._arX1[i], 2.0);
                }
                dx = (sumX2 / (double)cmnVal.EnVal._N) - Math.Pow(MatO, 2.0);
                return dx;
            }
            public double SkoX(double Disp)
            {
                double qx = 0.0;
                qx = Math.Sqrt(Disp);
                return qx;
            }
            public double Xi2(int i)
            {
                double xi2 = 0.0;
                xi2 = Math.Pow((cmnVal.OuVal._arTable[i, 3] - cmnVal.OuVal._arTable[i, 2]), 2.0) / cmnVal.OuVal._arTable[i, 3];
                return xi2;
            }
            public double sumXi2(double[,] arTable)
            {
                double sum = 0.0;
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    sum += arTable[i, 6];
                }
                return sum;
            }
            private double h(double Int)
            {
                double h = 0.0;
                h = Int / 2.0;
                return h;
            }
            public double fR(double Int, int i)
            {
                double R = 0.0;
                R = 0.1;
                return R;
            }
            public double fNorm(double Int, int i)
            {
                double norm, tmp1, tmp2, tmp3;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                tmp1 = 1.0 / (cmnVal.EnVal._Sko_T * Math.Sqrt(2.0 * Math.PI));
                tmp2 = (-1.0) * (Math.Pow((arA[i] - cmnVal.EnVal._MatO_T), 2.0)) / (2.0 * Math.Pow(cmnVal.EnVal._Sko_T, 2.0));
                tmp3 = Math.Exp(tmp2);
                norm = tmp1 * tmp3 * Int;
                return norm;
            }
            public double fExp(double Int, int i)
            {
                double exp;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                exp = (cmnVal.EnVal._Lya * Math.Exp((-1.0) * cmnVal.EnVal._Lya * arA[i])) * Int;
                return exp;
            }
            public double fXi2(double Int, int i)
            {
                double Xi2 = 0.0;
                double tmp1, tmp2, tmp3, tmp4;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                tmp1 = Math.Pow(arA[i], ((cmnVal.EnVal._V - 2.0) / 2.0));
                tmp2 = Math.Exp((-1.0) * arA[i] / 2.0);
                tmp3 = Math.Pow(2.0, (cmnVal.EnVal._V / 2.0));
                tmp4 = arGamma[0];
                Xi2 = ((tmp1 * tmp2) / (tmp3 * tmp4)) * Int;
                return Xi2;
            }
            public double fStudent(double Int, int i)
            {
                double f, f1, f2, f3, f4, f5, f6;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                f1 = arGamma[0];
                f2 = arGamma[1];
                f3 = Math.Sqrt(Math.PI * (double)cmnVal.EnVal._K);
                f4 = 1.0 + (Math.Pow(arA[i], 2.0) / (double)cmnVal.EnVal._K);
                f5 = ((double)cmnVal.EnVal._K + 1.0) / 2.0;
                f6 = (f1 / (f2 * f3)) * Math.Pow(f4, (-1.0 * f5));
                f = f6 * Int;
                return f;
            }
            public double fFisher(double Int, int i)
            {
                double f, f1, f2, f3, f4, f5, f6, f7;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                f1 = arGamma[0];
                f2 = arGamma[1] * arGamma[2];
                f3 = Math.Pow(((double)cmnVal.EnVal._K1 / (double)cmnVal.EnVal._K2), ((double)cmnVal.EnVal._K1 / 2.0));
                f4 = Math.Pow(arA[i], (((double)cmnVal.EnVal._K1 - 2.0) / 2.0));
                f6 = 1.0 * (cmnVal.EnVal._K1 + (double)cmnVal.EnVal._K2) / 2.0;
                f5 = Math.Pow((1.0 + (((double)cmnVal.EnVal._K1 * arA[i]) / (double)cmnVal.EnVal._K2)), f6);
                f7 = (f1 / f2) * f3 * (f4 / f5);
                f = Int * f7;
                return f;
            }
            public double fErlang(double Int, int i, int f3)
            {
                double f, f1, f2, f4;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                f1 = Math.Pow((cmnVal.EnVal._Lya * arA[i]), ((double)cmnVal.EnVal._K - 1.0));
                f2 = Math.Exp((-1.0) * cmnVal.EnVal._Lya * arA[i]);
                f4 = (cmnVal.EnVal._Lya * f1 * f2) / (double)f3;
                f = f4 * Int;
                return f;
            }
            public double fLogn(double Int, int i)
            {
                double f, f1;
                arA[i] = cmnVal.OuVal._arTable[i, 1] - h(Int);
                f1 = (1.0 / (arA[i] * cmnVal.EnVal._Sko_T * Math.Sqrt(2.0 * Math.PI))) * Math.Exp(((-1.0) * Math.Pow((Math.Log(arA[i] / cmnVal.EnVal._M)), 2.0)) / (2.0 * Math.Pow(cmnVal.EnVal._Sko_T, 2.0)));
                f = f1 * Int;
                return f;
            }
            public void varR_T()
            {
                double P = 1.0;
                double C = 12.0;
                cmnVal.OuVal._MatO_T = 0.5;
                cmnVal.OuVal._Disp_T = P / C;
            }
            public void varNorm_T()
            {
                cmnVal.OuVal._MatO_T = cmnVal.EnVal._MatO_T;
                cmnVal.OuVal._Disp_T = Math.Pow(cmnVal.EnVal._Sko_T, 2.0);
            }
            public void varExp_T()
            {
                cmnVal.OuVal._MatO_T = 1.0 / cmnVal.EnVal._Lya;
                cmnVal.OuVal._Disp_T = 1.0 / Math.Pow(cmnVal.EnVal._Lya, 2.0);
            }
            public void varXi2_T()
            {
                cmnVal.OuVal._MatO_T = cmnVal.EnVal._V;
                cmnVal.OuVal._Disp_T = 2.0 * cmnVal.EnVal._V;
            }
            public void varSt_T()
            {
                cmnVal.OuVal._MatO_T = 0.0;
                cmnVal.OuVal._Disp_T = cmnVal.EnVal._K / (cmnVal.EnVal._K - 2.0);
            }
            public void varF_T()
            {
                cmnVal.OuVal._MatO_T = cmnVal.EnVal._K2 / (cmnVal.EnVal._K2 - 2.0);
                cmnVal.OuVal._Disp_T = 2 * (Math.Pow(cmnVal.EnVal._K2, 2.0) * (cmnVal.EnVal._K1 + cmnVal.EnVal._K2 - 2.0)) / (cmnVal.EnVal._K1 * Math.Pow((cmnVal.EnVal._K2 - 2.0), 2.0) * (cmnVal.EnVal._K2 - 4.0));
            }
            public void varEr_T()
            {
                cmnVal.OuVal._MatO_T = cmnVal.EnVal._K / cmnVal.EnVal._Lya; //мат ожидание
                cmnVal.OuVal._Disp_T = cmnVal.EnVal._K / Math.Pow(cmnVal.EnVal._Lya, 2.0); //дисперсия  
            }
            public void varLogn_T()
            {
                double w = Math.Exp(Math.Pow(cmnVal.EnVal._Sko_T, 2));
                cmnVal.OuVal._MatO_T = cmnVal.EnVal._M * Math.Sqrt(w);
                cmnVal.OuVal._Disp_T = Math.Pow(cmnVal.EnVal._M, 2.0) * w * (w - 1.0);
            }
            public CommonValues.OutValues fAvgAll(ArrayList needCollection)
            {
                CommonValues.OutValues ouValAvg = new CommonValues.OutValues();
                int nCountCollect = needCollection.Count;
                ouValAvg._arTable = new double[cmnVal.EnVal._Ntb, 7];
                //
                for (int i = 0; i < nCountCollect; i++)
                {
                    cmnVal.OuVal = (CommonValues.OutValues)needCollection[i];
                    ouValAvg._MatO += cmnVal.OuVal._MatO / (double)nCountCollect;
                    ouValAvg._Disp += cmnVal.OuVal._Disp / (double)nCountCollect;
                    ouValAvg._Sko += cmnVal.OuVal._Sko / (double)nCountCollect;
                    ouValAvg._maxfFR += cmnVal.OuVal._maxfFR / (float)nCountCollect;
                    int nColArTable = 7;
                    for (int j = 0; j < nColArTable; j++)
                    {
                        for (int i_tbl = 0; i_tbl < cmnVal.EnVal._Ntb; i_tbl++)
                        {
                            ouValAvg._arTable[i_tbl, j] += cmnVal.OuVal._arTable[i_tbl, j] / (double)nCountCollect;
                        }
                    }
                    int nRowArX = cmnVal.OuVal._arX1.Length;
                    ouValAvg._arX1 = new double[nRowArX];
                    for (int iR = 0; iR < nRowArX; iR++)
                    {
                        ouValAvg._arX1[iR] += cmnVal.OuVal._arX1[iR] / nCountCollect;
                    }
                }
                cmnVal.OuVal = (CommonValues.OutValues)needCollection[nCountCollect - 1];
                ouValAvg._MatO_T = cmnVal.OuVal._MatO_T;
                ouValAvg._Disp_T = cmnVal.OuVal._Disp_T;
                ouValAvg._Sko_T = cmnVal.OuVal._Sko_T;
                ouValAvg._Xi2_T = cmnVal.OuVal._Xi2_T;
                return ouValAvg;
            }
            private float maxfF()
            {
                float max = 0;
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    if (max > cmnVal.OuVal._arTable[i, 5])
                    {
                        max = max;
                    }
                    else
                    {
                        max = (float)cmnVal.OuVal._arTable[i, 5];
                    }
                }
                return max;
            }
            private float maxfR()
            {
                float max = 0;
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    if (max > cmnVal.OuVal._arTable[i, 4])
                    {
                        max = max;
                    }
                    else
                    {
                        max = (float)cmnVal.OuVal._arTable[i, 4];
                    }
                }
                return max;
            }
            public float maxFR()
            {
                float max = 0;
                max = Math.Max(maxfF(), maxfR());
                return max;
            }
        }
        public class Processing
        {
            private Functions Func;
            private CommonValues cmnVal;
            private Core cr;
            private double[] arF;
            public Processing(CommonValues CmnVal, Functions Func)
            {
                this.cmnVal = CmnVal;
                cr = cmnVal.Cr;
                this.Func = Func;
            }
            public void Calculation()
            {
                /*double Int = (Math.Abs(Func.maxX(cmnVal.OuVal._arX)) + Math.Abs(Func.minX(cmnVal.OuVal._arX))) / (double)cmnVal.EnVal._Ntb;
                double sumInt = Func.minX(cmnVal.OuVal._arX);
                cmnVal.OuVal._arTable = new double[cmnVal.EnVal._Ntb, 7];
                arF = new double[cmnVal.EnVal._Ntb];
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    cmnVal.OuVal._arTable[i, 0] = i + 1;
                    sumInt += Int;
                    cmnVal.OuVal._arTable[i, 1] = sumInt;
                    for (int j = 0; j < cmnVal.EnVal._N; j++)
                    {
                        if (cmnVal.OuVal._arTable[i, 1] - Int <= cmnVal.OuVal._arX[j] && cmnVal.OuVal._arX[j] < cmnVal.OuVal._arTable[i, 1])
                        {
                            cmnVal.OuVal._arTable[i, 2]++;
                        }
                    }
                    cmnVal.OuVal._arTable[i, 4] = cmnVal.OuVal._arTable[i, 2] / (double)cmnVal.EnVal._N;
                    findF(Int);
                    cmnVal.OuVal._arTable[i, 5] = arF[i];
                    cmnVal.OuVal._arTable[i, 3] = cmnVal.OuVal._arTable[i, 5] * (double)cmnVal.EnVal._N;
                    cmnVal.OuVal._arTable[i, 6] = Func.Xi2(i);
                }
                */
                //
                //Генерируем закон распределения
                //
                
                //
                cmnVal.EnVal._Ntb = cr.AnalysData.Var.CountIntervals;
                cmnVal.EnVal._N = cr.AnalysData.Var.SourceTable.Rows.Count;
                cmnVal.OuVal._arTable = new double[cmnVal.EnVal._Ntb, 7];
                arF = new double[cmnVal.EnVal._Ntb];
                //
                cmnVal.OuVal._MaxValue = Func.maxXDt(cr.AnalysData.Var.SourceTable, cr.AnalysData.Var.NameParam);
                cmnVal.EnVal._Step = (cmnVal.OuVal._MaxValue + Math.Abs(cmnVal.OuVal._MinValue)) / (double)cmnVal.EnVal._Ntb;
                //
                 double sumSteps = cmnVal.OuVal._MinValue;
                //
                cmnVal.OuVal._arX1 = new double[cmnVal.EnVal._N];
                int indexArX = 0;
                //
                foreach (DataRow r in cr.AnalysData.Var.SourceTable.Rows)
                {
                    cmnVal.OuVal._arX1[indexArX] = cr.AnalysData.returnNullDouble(r[cr.AnalysData.Var.NameParam]);
                    indexArX++;
                }
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    cmnVal.OuVal._arTable[i, 0] = i + 1;
                    sumSteps += cmnVal.EnVal._Step;
                    cmnVal.OuVal._arTable[i, 1] = sumSteps;
                    for (int j = 0; j < cmnVal.EnVal._N; j++)
                    {
                        if (cmnVal.OuVal._arTable[i, 1] - cmnVal.EnVal._Step <= cmnVal.OuVal._arX1[j] && cmnVal.OuVal._arX1[j] < cmnVal.OuVal._arTable[i, 1])
                        {
                            cmnVal.OuVal._arTable[i, 2]++;
                        }
                    }
                    cmnVal.OuVal._arTable[i, 4] = cmnVal.OuVal._arTable[i, 2] / (double)cmnVal.EnVal._N;
                }
                //
                //cmnVal.EnVal.FrequencyE = 
                //
                cmnVal.OuVal._MatO = Func.MatOX();
                cmnVal.OuVal._Disp = Func.DispX(cmnVal.OuVal._MatO);
                cmnVal.OuVal._Sko = Func.SkoX(cmnVal.OuVal._Disp);
                //
                cmnVal.EnVal._MatO_T = (float)cmnVal.OuVal._MatO;
                cmnVal.EnVal._Sko_T = (float)cmnVal.OuVal._Sko;
                //
                GenerateX genX = new GenerateX(cmnVal);
                //
                findF(cmnVal.EnVal._Step);
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    cmnVal.OuVal._arTable[i, 5] = arF[i];
                    cmnVal.OuVal._arTable[i, 3] = cmnVal.OuVal._arTable[i, 5] * (double)cmnVal.EnVal._N;
                    cmnVal.OuVal._arTable[i, 6] = Func.Xi2(i);
                }
                //
                
                cmnVal.OuVal._Xi2 = Func.sumXi2(cmnVal.OuVal._arTable);
                cmnVal.OuVal._Sko_T = Math.Sqrt(cmnVal.OuVal._Disp_T);
                //
                //Содание таблицы
                DataColumn dc1 = new DataColumn("Наименование");
                dc1.DataType = System.Type.GetType("System.String");
                DataColumn dc2 = new DataColumn("Значение");
                dc2.DataType = System.Type.GetType("System.Double");
                DataColumn[] arDc = new DataColumn[2];
                arDc[0] = dc1;
                arDc[1] = dc2;
                cmnVal.OuVal._Dt = new DataTable();
                cmnVal.OuVal._Dt.Columns.AddRange(arDc);
                DataRow row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Число наблюдений";
                row[dc2] = cmnVal.EnVal._N;
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Среднее значение";
                row[dc2] = Math.Round(cmnVal.OuVal._MatO,2);
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Среднее квадратическое отклонение";
                row[dc2] = Math.Round(cmnVal.OuVal._Sko,2);
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Максимальное значение";
                row[dc2] = cmnVal.OuVal._MaxValue;
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Минимальное значение";
                row[dc2] = cmnVal.OuVal._MinValue;
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Число интервалов группирования значений";
                row[dc2] = cmnVal.EnVal._Ntb;
                cmnVal.OuVal._Dt.Rows.Add(row);

                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Зничение критерия Х^2";
                row[dc2] = Math.Round(cmnVal.OuVal._Xi2, 2);
                cmnVal.OuVal._Dt.Rows.Add(row);
                //
                row = cmnVal.OuVal._Dt.NewRow();
                row[dc1] = "Критическая область значений критерия Х^2 при уровне значимости 0,05";
                row[dc2] = Math.Round(cmnVal.OuVal._Xi2_T,2);
                cmnVal.OuVal._Dt.Rows.Add(row);
                //


                //cmnVal.OuVal._Xi2 = Func.sumXi2(cmnVal.OuVal._arTable);
                //
                //cmnVal.OuVal._Sko_T = Math.Sqrt(cmnVal.OuVal._Disp_T);
                //
                //cmnVal.OuVal._maxfFR = Func.maxFR();
                //
                //Totals();
            }
            /*private void findF(double Int)
            {
                double[] arChG;
                int nG = 1;
                switch (sOn._rdChoice)
                {
                    case 10://Равномерное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fR(Int, i);
                            }
                            Func.varR_T();
                            break;
                        }
                    case 11://Нормальное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fNorm(Int, i);
                            }
                            Func.varNorm_T();
                            break;
                        }
                    case 12://Экспоненциальное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fExp(Int, i);
                            }
                            Func.varExp_T();
                            break;
                        }
                    case 13://хи-квадрат
                        {
                            nG = 1;
                            arChG = new double[nG];
                            arChG[0] = cmnVal.EnVal._V / 2.0;
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fXi2(Int, i);
                            }
                            Func.varXi2_T();
                            break;
                        }
                    case 14://Стьюдент
                        {
                            nG = 2;
                            arChG = new double[nG];
                            arChG[0] = ((double)(cmnVal.EnVal._K + 1.0)) / 2.0;
                            arChG[1] = (double)(cmnVal.EnVal._K / 2.0);
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fStudent(Int, i);
                            }
                            Func.varSt_T();
                            break;
                        }
                    case 15://Фишер
                        {
                            nG = 3;
                            arChG = new double[nG];
                            arChG[0] = ((double)(cmnVal.EnVal._K1 + cmnVal.EnVal._K2)) / 2.0;
                            arChG[1] = (double)(cmnVal.EnVal._K1 / 2.0);
                            arChG[2] = (double)(cmnVal.EnVal._K2 / 2.0);
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fFisher(Int, i);
                            }
                            Func.varF_T();
                            break;
                        }
                    case 16://Эрланг
                        {
                            int fact = Func.Fact(cmnVal.EnVal._K - 1);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fErlang(Int, i, fact);
                            }
                            Func.varEr_T();
                            break;
                        }
                    case 17://Логистическое
                        {
                            break;
                        }
                    case 18://Парето
                        {
                            break;
                        }
                    case 19://Логнормальное
                        {
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fLogn(Int, i);
                            }
                            Func.varLogn_T();
                            break;
                        }
                }
            }*/
            public void Totals()
            {
                cmnVal.OuVal._sumInt = 0;
                cmnVal.OuVal._sumNi = 0;
                cmnVal.OuVal._sumNi_T = 0;
                cmnVal.OuVal._sumCha = 0;
                cmnVal.OuVal._sumCha_T = 0;
                cmnVal.OuVal._sumXi2 = 0;
                for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                {
                    cmnVal.OuVal._sumInt += cmnVal.OuVal._arTable[i, 1];
                    cmnVal.OuVal._sumNi += (int)(cmnVal.OuVal._arTable[i, 2]);
                    cmnVal.OuVal._sumNi_T += cmnVal.OuVal._arTable[i, 3];
                    cmnVal.OuVal._sumCha += cmnVal.OuVal._arTable[i, 4];
                    cmnVal.OuVal._sumCha_T += cmnVal.OuVal._arTable[i, 5];
                    cmnVal.OuVal._sumXi2 += cmnVal.OuVal._arTable[i, 6];
                }
            }
            private void findF(double step)
            {
                double[] arChG;
                int nG = 1;
                switch (cmnVal.EnVal._TypeSpreading)
                {
                    case CommonValues.EnterValues.TypeSpreading.Random://Равномерное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fR(step, i);
                            }
                            Func.varR_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Normal://Нормальное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fNorm(step, i);
                            }
                            Func.varNorm_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Exponecial://Экспоненциальное
                        {

                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fExp(step, i);
                            }
                            Func.varExp_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Xi2://хи-квадрат
                        {
                            nG = 1;
                            arChG = new double[nG];
                            arChG[0] = cmnVal.EnVal._V / 2.0;
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fXi2(step, i);
                            }
                            Func.varXi2_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Student://Стьюдент
                        {
                            nG = 2;
                            arChG = new double[nG];
                            arChG[0] = ((double)(cmnVal.EnVal._K + 1.0)) / 2.0;
                            arChG[1] = (double)(cmnVal.EnVal._K / 2.0);
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fStudent(step, i);
                            }
                            Func.varSt_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Fisher://Фишер
                        {
                            nG = 3;
                            arChG = new double[nG];
                            arChG[0] = ((double)(cmnVal.EnVal._K1 + cmnVal.EnVal._K2)) / 2.0;
                            arChG[1] = (double)(cmnVal.EnVal._K1 / 2.0);
                            arChG[2] = (double)(cmnVal.EnVal._K2 / 2.0);
                            Func.Gamma(arChG, nG);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fFisher(step, i);
                            }
                            Func.varF_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Erlang://Эрланг
                        {
                            int fact = Func.Fact(cmnVal.EnVal._K - 1);
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fErlang(step, i, fact);
                            }
                            Func.varEr_T();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Logistical://Логистическое
                        {
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Pareto://Парето
                        {
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Lognormal://Логнормальное
                        {
                            for (int i = 0; i < cmnVal.EnVal._Ntb; i++)
                            {
                                arF[i] = Func.fLogn(step, i);
                            }
                            Func.varLogn_T();
                            break;
                        }
                }
            }
        }
        public class GenerateX
        {
            private CommonValues cmnVal;
            //
            private Random rnd1;
            private Random rnd2;
            //
            private _Rnd rnd;
            private _Norm nrm;
            private _Exp exp;
            private _Xi_two xi2;
            private _Student stu;
            private _Lognorm lognrm;
            //
            public _Rnd Rnd { get { return rnd; } }
            //
            public GenerateX(CommonValues CmnVal)
            {
                this.cmnVal = CmnVal;
                if (CmnVal != null)
                {
                    cmnVal.EnVal = cmnVal.EnVal;
                    cmnVal.OuVal = cmnVal.OuVal;
                    rnd1 = new Random();
                    rnd2 = new Random();
                    switchSpreading();
                }
            }
            private void switchSpreading()
            {
                /*
                 * 0 - равномерный
                 * 1 - нормальный
                 * 2 - экспоненциальный
                 * 3 - хи-квадрат
                 * 4 - стьюдент
                 * 5 - Фишер
                 * 6 - Эрланг
                 * 7 - Логистическое
                 * 8 - Парето
                 * 9 - Логнормальное
                 * */
                switch (cmnVal.EnVal._TypeSpreading)
                {
                    case CommonValues.EnterValues.TypeSpreading.Random:
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Normal://Нормальное
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            nrm = new _Norm(cmnVal, rnd);
                            nrm.generate();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Exponecial://Экспоненциальное
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            exp = new _Exp(cmnVal, rnd);
                            exp.generate();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Xi2://хи-квадрат
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            nrm = new _Norm(cmnVal, rnd);
                            xi2 = new _Xi_two(cmnVal, nrm);
                            xi2.generate();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Student://Стьюдент
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            nrm = new _Norm(cmnVal, rnd);
                            xi2 = new _Xi_two(cmnVal, nrm);
                            stu = new _Student(cmnVal, nrm, xi2);
                            stu.generate();
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Fisher://Фишер
                        {
                            /*nrm = new Norm(enVal, ouVal, R);
                            Xi2 = new Xi_two(enVal, ouVal, nrm);
                            //
                            R2 = new _5(rnd2, ouVal, enVal);
                            nrm2 = new Norm(enVal, ouVal, R2);
                            Xi2_2 = new Xi_two(enVal, ouVal, nrm2);
                            //
                            F = new Fisher(enVal, ouVal, Xi2, Xi2_2);
                            F.generate();*/
                            //
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Erlang://Эрланг
                        {
                            /*er = new Erlang(enVal, ouVal, R);
                            Er.generate();*/
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Logistical://Логистическое
                        {
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Pareto://Парето
                        {
                            break;
                        }
                    case CommonValues.EnterValues.TypeSpreading.Lognormal://Логнормальное
                        {
                            rnd = new _Rnd(rnd1, cmnVal);
                            nrm = new _Norm(cmnVal, rnd);
                            lognrm = new _Lognorm(cmnVal, nrm);
                            lognrm.generate();
                            break;
                        }
                }

                /*R = new _5(rnd, cmnVal.OuVal, cmnVal.EnVal);
                //
                switch (rdChoice)
                {
                    case 10://Равномерное
                        {
                            R.generate();
                            break;
                        }
                    case 11://Нормальное
                        {
                            nrm = new Norm(cmnVal.EnVal, cmnVal.OuVal, R);
                            nrm.generate();
                            break;
                        }
                    case 12://Экспоненциальное
                        {
                            Ex = new Exp(cmnVal.EnVal, cmnVal.OuVal, R);
                            Ex.generate();
                            break;
                        }
                    case 13://хи-квадрат
                        {
                            nrm = new Norm(cmnVal.EnVal, cmnVal.OuVal, R);
                            Xi2 = new Xi_two(cmnVal.EnVal, cmnVal.OuVal, nrm);
                            Xi2.generate();
                            break;
                        }
                    case 14://Стьюдент
                        {
                            nrm = new Norm(cmnVal.EnVal, cmnVal.OuVal, R);
                            Xi2 = new Xi_two(cmnVal.EnVal, cmnVal.OuVal, nrm);
                            St = new Student(cmnVal.EnVal, cmnVal.OuVal, nrm, Xi2);
                            St.generate();
                            break;
                        }
                    case 15://Фишер
                        {
                            nrm = new Norm(cmnVal.EnVal, cmnVal.OuVal, R);
                            Xi2 = new Xi_two(cmnVal.EnVal, cmnVal.OuVal, nrm);
                            //
                            R2 = new _5(rnd2, cmnVal.OuVal, cmnVal.EnVal);
                            nrm2 = new Norm(cmnVal.EnVal, cmnVal.OuVal, R2);
                            Xi2_2 = new Xi_two(cmnVal.EnVal, cmnVal.OuVal, nrm2);
                            //
                            F = new Fisher(cmnVal.EnVal, cmnVal.OuVal, Xi2, Xi2_2);
                            F.generate();
                            //
                            break;
                        }
                    case 16://Эрланг
                        {
                            Er = new Erlang(cmnVal.EnVal, cmnVal.OuVal, R);
                            Er.generate();
                            break;
                        }
                    case 17://Логистическое
                        {
                            break;
                        }
                    case 18://Парето
                        {
                            break;
                        }
                    case 19://Логнормальное
                        {
                            nrm = new Norm(cmnVal.EnVal, cmnVal.OuVal, R);
                            Log = new Lognorm(cmnVal.EnVal, cmnVal.OuVal, nrm);
                            Log.generate();
                            break;
                        }
                }
                Pr.Calculation();
                return cmnVal.OuVal;*/
            }
            //
            public class _Rnd
            {
                private Random rnd;
                private CommonValues cmnVal;
                public _Rnd(Random rnd, CommonValues CmnVal)
                {
                    this.rnd = rnd;
                    this.cmnVal = CmnVal;
                    generate();
                }
                public double RavnX()
                {
                    return rnd.NextDouble() * 1.0;
                }
                public void generate()
                {
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.OuVal._NameOfR = "Равномерное распределение";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = RavnX();
                    }
                }
            }
            public class _Norm
            {
                private _Rnd rnd;
                private CommonValues cmnVal;
                //
                public _Norm(CommonValues CmnVal, _Rnd Rnd)
                {
                    this.cmnVal = CmnVal;
                    rnd = Rnd;
                }
                //
                public void generate()
                {
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.OuVal._NameOfR = "Нормальное распределение";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = genX(cmnVal.EnVal._MatO_T, cmnVal.EnVal._Sko_T);
                    }
                }
                private double sumR()
                {
                    double sum = 0;
                    for (int i = 0; i < cmnVal.EnVal._sumR; i++)
                    {
                        sum += rnd.RavnX();
                    }
                    return sum;
                }
                public double genX(double MatO_T, double Sko_T)
                {
                    //случайное число равное сумме N равномерно распределенных случайных величин
                    double v = 0.0;
                    // мат ожидание суммы случайных величин
                    double mv = 0.0;
                    // с.к.о. суммы случайных величин
                    double qv = 0.0;
                    // нормализованое знаение v
                    double z = 0.0;
                    // случайная величина с задаными с.к.о. и мат ожиданием
                    double x = 0.0;
                    v = sumR();
                    mv = cmnVal.EnVal._sumR / 2.0;
                    qv = Math.Sqrt(cmnVal.EnVal._sumR / 12.0);
                    //нормализуем полученное значение
                    z = (v - mv) / qv;
                    //Формулой (сдвиг на mx  и масштабирование на qx) преобразуем ряд Z в ряд x
                    x = z * Sko_T + MatO_T;
                    return x;
                }
            }
            public class _Exp
            {
                private _Rnd rnd;
                private CommonValues cmnVal;
                public _Exp(CommonValues CmnVal, _Rnd Rnd)
                {
                    this.rnd = Rnd;
                    this.cmnVal = CmnVal;
                }
                public void generate()
                {
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.OuVal._NameOfR = "Экспоненциальное распределение";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = (-1.0) * (1.0 / cmnVal.EnVal._Lya) * Math.Log(1.0 - rnd.RavnX());
                    }
                }
            }
            public class _Xi_two
            {
                private CommonValues cmnVal;
                private _Norm nrm;
                public _Xi_two(CommonValues CmnVal, _Norm Nrm)
                {
                    this.cmnVal = CmnVal;
                    this.nrm = Nrm;
                }
                public void generate()
                {
                    cmnVal.EnVal._MatO_T = 0.0f;
                    cmnVal.EnVal._Sko_T = 1.0f;
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.OuVal._NameOfR = "Расмпределение 'хи-квадрат'";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = genX(cmnVal.EnVal._MatO_T, cmnVal.EnVal._Sko_T, cmnVal.EnVal._K);
                    }
                }
                public double genX(float MatO, float Sko, int K)
                {
                    double x = 0.0;
                    for (int j = 0; j < K; j++)
                    {
                        x += Math.Pow(nrm.genX(MatO, Sko), 2.0);
                    }
                    return x;
                }
                public double genXf()
                {
                    double x = 0.0;
                    return x;
                }
            }
            public class _Student
            {
                private CommonValues cmnVal;
                private _Norm nrm;
                private _Xi_two xi2;
                public _Student(CommonValues CmnVal, _Norm Nrm, _Xi_two Xi2)
                {
                    this.cmnVal = CmnVal;
                    this.nrm = Nrm;
                    this.xi2 = Xi2;
                }
                public void generate()
                {
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.EnVal._MatO_T = 0.0f;
                    cmnVal.EnVal._Sko_T = 1.0f;
                    cmnVal.OuVal._NameOfR = "Распределение Стьюдента";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = genX(cmnVal.EnVal._MatO_T, cmnVal.EnVal._Sko_T, cmnVal.EnVal._K);
                    }
                }
                private double genX(float MatO, float Sko, int K)
                {
                    double x = 0.0;
                    double Xi2_K = 0.0;
                    Xi2_K = xi2.genX(MatO, Sko, K);
                    x = nrm.genX(MatO, Sko) / Math.Sqrt(Xi2_K / (double)K);
                    return x;
                }
            }
            public class _Lognorm
            {
                private CommonValues cmnVal;
                private _Norm nrm;
                public _Lognorm(CommonValues CmnVal, _Norm Nrm)
                {
                    this.cmnVal = CmnVal;
                    this.nrm = Nrm;
                }
                public void generate()
                {
                    cmnVal.OuVal._arX2 = new double[cmnVal.EnVal._N];
                    cmnVal.EnVal._MatO_T = 0.0f;
                    cmnVal.OuVal._NameOfR = "Логнормальное распределение";
                    for (int i = 0; i < cmnVal.EnVal._N; i++)
                    {
                        cmnVal.OuVal._arX2[i] = genX(cmnVal.EnVal._MatO_T, cmnVal.EnVal._Sko_T, cmnVal.EnVal._M);
                    }
                }
                private double genX(float MatO, float Sko, float M)
                {
                    double x = 0.0;
                    float nrmSko = 1.0f;
                    x = Math.Exp(Sko * nrm.genX(MatO, nrmSko)) * M;
                    return x;
                }
            }
        }
    }
}
