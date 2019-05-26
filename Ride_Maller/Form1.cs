using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ride_Maller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool activateError = false;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Main()
        {

            int m = 6;
            int n = Convert.ToInt16(Math.Pow(2, m));
            int k = 0;
            int s = 2;
          
            for (int i = 0; i <= s; i++)
            {
                k += (int)(factorial(m) / (factorial(i) * factorial(m - i)));
            }
            int r = n - k;

            int count = 0;
            string mes = textBox1.Text;

            StringBuilder mes_str = new StringBuilder();
            mes_str.Append(mes);
            /*    foreach(char c in textBox1.Text)
                 {
                      = c;
                     string me = Convert.ToString(mes, 2);


                     if(mes_str.Length<=k)
                     {
                         break;
                     }
                 }*/

            int[,] matrix = new int[r, n];
            for (int w = 0; w < r; w++)
            {
                for (int e = 0; e < n; e++)
                {
                    matrix[w, e] = 0;

                }

            }
            for (int i = 0; i < n; i++)
            {
                matrix[0, i] = 1;
            }
            matrix = BuildMatrix(matrix,k, n, m);
            
            int permut = (int)(factorial(m) / (factorial(s) * factorial(m - s)));
            int[,] permut_arr = new int[m, m];

            for (int y = 0; y < m; y++)
            {
                for (int i = 0; i < m; i++)
                {

                    if (y == i)
                    {
                        continue;
                    }
                    if (permut_arr[i, y] == 1)
                    {
                        continue;
                    }
                    permut_arr[y, i] = 1;

                }
            }

            int q = (m + 1);
            for (int j = 0; j < m; j++)
            {
                if (q >= k)
                {
                    break;
                }
                for (int e = 0; e < m; e++)
                {
                    if (permut_arr[j, e] == 1)
                    {
                        matrix = MultStrings(matrix, j, e, n, q);
                        q++;
                    }
                }
            }

            int[] u = new int[n];

          
            List<int> u1 = new List<int> { };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        u1.Add(j);

                    }

                }
                u1.Add('+');
            }


         
            int[] numbers_u1 = u1.ToArray<int>();
        
            count = 0;
            int qw = 0;
            StringBuilder encode_mes = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                while (u1[count] != 43)
                {

                    int ind =u1[count];

                    int num = Convert.ToInt16(mes_str[ind]);
                    num = num == 48 ? 0 : 1;
                    qw ^= num;
                    count++;
                }
                encode_mes.Append(qw.ToString());
                qw = 0;
                count++;

            }



            ///

            StringBuilder mes_str_error = new StringBuilder();
            mes_str_error = encode_mes;
            if (activateError)
            {
                mes_str_error = Error(encode_mes,m, n);
            }






            StringBuilder ind1 = new StringBuilder();
            StringBuilder k0 = new StringBuilder();
            StringBuilder k1 = new StringBuilder();

            for (int i = 0; i < m; i++)
            {

                for (int e = 0; e < m; e++)
                {
                    if (permut_arr[i, e] == 1)
                    {
                        
                            ind1.Append(i.ToString());
                       
                    }
                }
            }
            List<int> ind_0 = new List<int>();
            List<int> ind_1 = new List<int>();
            // int[] ind_0 = new int[(k - (m + 1)) * n / 2 + ((n / 2 - 1) * k - (m + 1))];
            //int[] ind_1 = new int[(k - (m + 1)) * n / 2 + ((n / 2) * k - (m + 1))];
            int pointer = 0;
            int pointer1 = 0;
            for (int j = m + 1; j < k; j++)
            {
                int t = 0;
                int t1 = 0;
                int c = 0;
                int t2 = 0;
                for (int i = 0; i < n; i++)
                {


                    t = matrix[j, i];
                    int wew = (int)Char.GetNumericValue(ind1[j - (m + 1)]);
                    wew =(int) Math.Pow(2, wew);

                    t1 = matrix[j, i + wew];
                    t2 = t ^ t1;
                    if (t2 == 0)
                    {
                        ind_0.Insert(pointer, i);
                        pointer++;
                        ind_0.Insert(pointer ,(i + wew));
                        pointer++;
                        ind_0.Insert(pointer,(int)'P');
                        pointer++;
                    }
                    if (t2 == 1)
                    {
                        ind_1.Insert(pointer1, i);
                        pointer1++;
                        ind_1.Insert(pointer1, i+wew);
                        pointer1++;
                        ind_1.Insert(pointer1, (int)'P');
                        pointer1++;
                    }


                    c++;
                    if (c % (wew) == 0)
                    {
                         i += wew;
 
                    }

                }
                c = 0;

            }
            int numb = 0;
            pointer = 0;
            List<int> ind_res = new List<int>();
            //  int[] ind_res = new int[(k - (m + 1)) * n + ((n/(m-2)) * (k - (m + 1)))];
            int counter = 0;

            for (int i = 0; i <ind_0.Count; i++)
            {

                if(i==ind_1.Count)
                {
                    break;
                }

                if (ind_0[i] == 80 || ind_1[i] == 80)
                {
                    continue;
                }
               
                ind_res.Insert(pointer,ind_0[i]);
                pointer++;
                ind_res.Insert(pointer, ind_0[i+1]);
                pointer++;
                 ind_res.Insert(pointer, ind_1[i]);
                 pointer++;
                ind_res.Insert(pointer, ind_1[i + 1]);
                pointer++;
        
                i +=2;
                counter += 4;//2^(m-s)=2^(6-2)=16
                if (counter % 4 == 0)
                {
                    ind_res.Insert(pointer,(int)'P');
                    pointer++;
                }

            }
            count = 0;
            qw = 0;
            int sum = 0;




            /////Decoooode
            StringBuilder decode_mes = new StringBuilder(k);
            for (int i = m+1; i <k; i++)
            {

                while (true)
                {

                    while (ind_res[count] != 80)
                    {


                        int ind = ind_res[count];
                        int num = Convert.ToInt16(mes_str_error[ind]);
                        num = num == 48 ? 0 : 1;
                        qw ^= num;

                        count++;
                    }
                    sum += qw;
                    qw = 0;
                    count++;
                    if(count % (n+n/4)==0)
                    {
                        break;
                    }
                }


                if (sum <= m / 2)
                {
                    decode_mes.Append('0');
                }
                if (sum > m / 2)
                {
                    decode_mes.Append('1');
                }
                qw = 0;
                sum = 0;
                //count++;
            }
            for (int i = 0; i < m; i++)
            {
                decode_mes.Insert(i, ('0'));

            }
            StringBuilder transform = new StringBuilder();
            
           List <int> param = new List<int> { };
            List<int> ones = new List<int>() { };
            for (int i=0;i<decode_mes.Length;i++)
            {
                if(decode_mes[i]=='1')
                {
                    ones.Add(i+1);
                }
            }
           /////
                for (int i = 0; i < n; i++)
                {
                int num = Convert.ToInt16(mes_str_error[i]);
                num = num == 48 ? 0 : 1;
                param.Add(num);
                }
            sum = 0;
            
           // 
                for (int i=0;i<ones.Count;i++)
                 {

                    for (int y = 0; y < n; y++)
                    {
                        param[y] = param[y] ^ matrix[ones[ones.Count-i-1], y];


                    }
                 }
                    for (int j = 0; j < n; j++)
                  {
                       transform.Append(param[j]);
                   }
            ////

            List<int> ind1_0 = new List<int>();
          //  List<int> ind1_1 = new List<int>();
            // int[] ind1_0 = new int[(n +(n / 2))*m];
           // int[] ind1_1 = new int[(k - (m + 1)) * n / 2 + ((n / 2) * k - (m + 1))];
           
             pointer = 0;
            int c1 = 0;
            for (int j = 1; j < m+1; j++)
            {
                for (int i = 0; i < n; i++)
                {

                    int wew = (int)Math.Pow(2, (j - 1));

                    ind1_0.Insert(pointer,i);
                    pointer++;
                    ind1_0.Insert(pointer, (i + wew));
                    pointer++;
                    ind1_0.Insert(pointer,(int)'P');
                    pointer++;

                    c1++;
                    if (c1 % (wew) == 0)
                    {
                             i += wew;

                    }

                }
                c1 = 0;
          
                

            }

         
            count = 0;
            qw = 0;
            sum = 0;
            for (int i =m; i >0; i--)
            {

                while (true)
                {

                    while (ind1_0[count] != 80)
                    {


                        int ind = ind1_0[count];
                        int num = Convert.ToInt16(transform[ind]);
                        num = num == 48 ? 0 : 1;
                        qw ^= num;

                        count++;
                    }
                    sum += qw;
                    qw = 0;
                    count++;
                    if(count % (n + n/2) == 0)
                    {
                        break;
                    }
                }


                if (sum <= m / 2)
                {
                    decode_mes.Insert(m-i+1, ('0'));
                    decode_mes.Remove((m-i),1);
                   
                   
                }
                if (sum > m / 2)
                {
                    decode_mes.Insert(m - i+1, ('1'));
                    decode_mes.Remove((m - i ), 1);
                    
                    
                }
                sum = 0;
                qw = 0;

            }
            /////
            ///

            StringBuilder decode_res = new StringBuilder();
            //
            sum = 0;
            ones.Clear();
            for(int i=0;i<m;i++)
            {
                if(decode_mes[i]=='1')
                {
                    ones.Add(i+1);
                }
            }
            param.Clear();
            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt16(transform[i]);
                num = num == 48 ? 0 : 1;
                param.Add(num);
            }
            sum = 0;

            for (int i = 0; i < ones.Count; i++)
            {

                for (int y = 0; y < n; y++)
                {
                    param[y] = param[y] ^ matrix[ones[ones.Count - i - 1], y];


                }
            }
            for (int j = 0; j < n; j++)
            {
                decode_res.Append(param[j]);
            }
            ////

            count = 0;
            for(int i=0;i<n;i++)
            {
                if (decode_res[i]=='1')
                {
                    count++;
                }

            }
            
            if(count>n/2)
            {
                decode_mes.Insert(0, ('1'));
            }
            else
            {
                decode_mes.Insert(0, ('0'));
            }
            label2.Text = encode_mes.ToString();
            label3.Text = decode_mes.ToString();
            if(activateError)
            {
            label6.Text = mes_str_error.ToString();
            }
            
        }
     

         
            private int [,] MultStrings(int [,] matrix,int j,int e,int n,int q)
        {
            int res = 0;
            for(int r=0;r<n;r++)
            {
                res = matrix[j + 1,r] & matrix[e + 1, r];
                matrix[q, r] = res;

            }
            return matrix;
        }
        static long factorial(long x) { return x <= 1 ? 1 : x * factorial(x - 1); }

        private int [,]BuildMatrix(int[,] matrix, int r, int n,int m)
        {
            
            int x = 0;
            int w = 0; 
            int count = m;
             for (int q = 0; q < n; q++)
             {
                 string temp = Convert.ToString(q, 2);
                 int y = temp.Length;
                 for (int j = 1; j < m+1; j++)
                 {
                    
                    if(y==0)
                    {
                        matrix[j, q] = x;
                    }
                    else
                    {
                        matrix[j,q]=(int)Char.GetNumericValue( temp[y-1]);
                        y--;
                    }
                   
                 }
             }

             /*
            while (i < m+1)
            {


                int y = Convert.ToInt16(Math.Pow(2, x));
                w = 0;
                while ((y + w) < n)
                {
                    matrix[i, y + w] = 1;


                    for (int j = 1; j < y && (y + j) < n; j++)
                    {
                        matrix[i, y + w + j] = 1;
                        count++;
                    }

                    w += y + 1+count;

                    count = 0;

                }
                i++;
                x++;

            }*/
            return matrix;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main();
        }

        private StringBuilder Error(StringBuilder message,int m, int n)
        {
            Random rnd = new Random();
            int count = 3;
                //rnd.Next(1,m+1 );
            for(int i=0;i<count;i++)
            {
                int y = rnd.Next(0, n);
                message[y] = message[y] == '1' ? '0' : '1';
            }
            return message;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            activateError = true;
        }
    }
}
