using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassChecker
{
    public partial class PasswordChecker : Form
    {
        public PasswordChecker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string strength = CheckPasswordStrength(password);
            labelResult.Text = strength;
        }
        private string CheckPasswordStrength(string password)
        {
          
            int score = 0;
            int charSetSize = 0;

            if (Regex.IsMatch(password, @"[A-Z]")) { score++; charSetSize += 26; } // 大文字
            if (Regex.IsMatch(password, @"[a-z]")) { score++; charSetSize += 26; } // 小文字
            if (Regex.IsMatch(password, @"[0-9]")) { score++; charSetSize += 10; } // 数字
            if (Regex.IsMatch(password, @"[!@#$%^&*()_+=-]")) { score++; charSetSize += 32; } // 特殊文字

            string strengthMessage;
            tCalculation(password, charSetSize);
            // パスワードの強度評価

            strengthMessage = "スコア:"+score.ToString();
            return strengthMessage;

        }

        private void tCalculation(string st , int cha )
        {

            // 総当たり時間の計算
            double totalCombinations = Math.Pow(cha, st.Length);
            double secondsToCrack = totalCombinations / 1000000; // 1秒間に100万回試行
            double minutesToCrack = secondsToCrack / 60;

            string timeMessage = minutesToCrack < 1
                ? $"{Math.Round(secondsToCrack, 2)}秒"
                : $"{Math.Round(minutesToCrack, 2)}分";

           label1.Text ="解析にかかる時間 \n約"+ timeMessage;
            label5.Text = "※総当たりの場合";
        }

    }
}
