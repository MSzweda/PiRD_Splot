using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;

namespace PiRD_Splot
{
    public partial class MainWindow : Form
    {
        private int speed = 50;
        private int speed_2 = 50;
        private int speed_3 = 50;
        private int speed_4 = 50;

        PointPairList list1_1;
        PointPairList list1_2;
        PointPairList list1_3;

        PointPairList list2_1;
        PointPairList list2_2;
        PointPairList list2_3;

        PointPairList list3_1;
        PointPairList list3_2;
        PointPairList list3_3;

        PointPairList list4_1;
        PointPairList list4_2;
        PointPairList list4_3;

        Thread animate;
        Thread animate2;
        Thread animate3;
        Thread animate4;



        public MainWindow()
        {
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //speeds
            speed1.Value = speed;
            speed2.Value = speed_2;
            speed3.Value = speed_3;
            speed4.Value = speed_4;
            //panes
            loadGraphPane(zedGraphControl1);
            loadGraphPane(zedGraphControl2);
            loadGraphPane(zedGraphControl3);

            loadGraphPane(zgc21);
            loadGraphPane(zgc22);
            loadGraphPane(zgc23);
            
            initGraphsFor1();
            initGraphsFor2();

            animate = new Thread(new ThreadStart(animateFor1));
            animate2 = new Thread(new ThreadStart(animateFor2));
            
            loadGraphPane(zgc31);
            loadGraphPane(zgc32);
            loadGraphPane(zgc33);
            loadGraphPane(zgc41);
            loadGraphPane(zgc42);
            loadGraphPane(zgc43);
            initGraphsFor3();
            initGraphsFor4();
            animate3 = new Thread(new ThreadStart(animateFor3));
            animate4 = new Thread(new ThreadStart(animateFor4));
             
        }


        //zamknac watki przy zamknieciu okna
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (animate.IsAlive)
            {
                if (animate.ThreadState == ThreadState.Suspended) animate.Resume();
                animate.Abort();
            }
            if (animate2.IsAlive)
            {
                if (animate2.ThreadState == ThreadState.Suspended) animate2.Resume();
                animate2.Abort();
            }
            if (animate3.IsAlive)
            {
                if (animate3.ThreadState == ThreadState.Suspended) animate3.Resume();
                animate3.Abort();
            }
             if (animate4.IsAlive)
            {
                if (animate4.ThreadState == ThreadState.Suspended) animate4.Resume();
                animate4.Abort();
            }
             
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (animate.IsAlive)
            {
                if (animate.ThreadState == ThreadState.Suspended) animate.Resume();
                animate.Abort();
            }
            if (animate2.IsAlive)
            {
                if (animate2.ThreadState == ThreadState.Suspended) animate2.Resume();
                animate2.Abort();
            }
            if (animate3.IsAlive)
            {
                if (animate3.ThreadState == ThreadState.Suspended) animate3.Resume();
                animate3.Abort();
            }
            if (animate4.IsAlive)
            {
               if (animate4.ThreadState == ThreadState.Suspended) animate4.Resume();
               animate4.Abort();
            }
        }

        //przejscie do poprzedniego taba
        private void btnPowrot_Click(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if (index > 0) tabControl1.SelectedTab = tabControl1.TabPages[index - 1];
        }

        //przejscie do nastepnego taba
        private void btnDalej_Click(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if (index < tabControl1.TabCount - 1) tabControl1.SelectedTab = tabControl1.TabPages[index + 1];
        }
        //sprawdzenie odpowiedzi na pytanie 1
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                odp1Label.ForeColor = System.Drawing.Color.ForestGreen;
                odp1Label.Text = "Odpowiedź prawidłowa";
                alg21.Enabled = true;
            }
            else
            {
                odp1Label.ForeColor = System.Drawing.Color.Crimson;
                odp1Label.Text = "Odpowiedź nieprawidłowa";
            }
        }

        //wyswietlenie okna podpowiedzi 1
        private void button6_Click(object sender, EventArgs e)
        {
            Hint1 h1 = new Hint1();
            h1.Show();
        }

        //wyswietlanie obrazka przy odpowiedziach zadania 2
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_1;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_2;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_3;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_4;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_5;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                pictureBox10.Image = images.wykres_6_6;
            }
        }

        //sprawdzenie zadania 2
        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                odp2Label.ForeColor = System.Drawing.Color.ForestGreen;
                odp2Label.Text = "Odpowiedź prawidłowa";
                alg31.Enabled = true;
            }
            else
            {
                odp2Label.ForeColor = System.Drawing.Color.Crimson;
                odp2Label.Text = "Odpowiedź nieprawidłowa";
            }
        }

        //okno podpowiedzi 2
        private void button7_Click(object sender, EventArgs e)
        {
            Hint2 h2 = new Hint2();
            h2.Show();
        }

        //wyswietlanie obrazka przy odpowiedziach zadania 3
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18.Checked == true)
            {
                pictureBox13.Image = images.wykres_6_5;
            }
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton17.Checked == true)
            {
                pictureBox13.Image = images.wykres_6_3;
            }
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == true)
            {
                pictureBox13.Image = images.wykres_6_1;
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                pictureBox13.Image = images.wykres_6_4;
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                pictureBox13.Image = images.wykres_6_6;
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked == true)
            {
                pictureBox13.Image = images.wykres_7_1;
            }
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton19.Checked == true)
            {
                pictureBox13.Image = images.wykres_7_2;
            }
        }

        //sprawdzenie zadania 3
        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton13.Checked == true)
            {
                odp3Label.ForeColor = System.Drawing.Color.ForestGreen;
                odp3Label.Text = "Odpowiedź prawidłowa";
                alg41.Enabled = true;
            }
            else
            {
                odp3Label.ForeColor = System.Drawing.Color.Crimson;
                odp3Label.Text = "Odpowiedź nieprawidłowa";
            }
        }

        //ustawienia poczatkowe paneli grafow
        private void loadGraphPane(ZedGraphControl zgc)
        {
            GraphPane myPane;
            myPane = zgc.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
            myPane.YAxis.Scale.Max = 1.1;
            myPane.YAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 80;
            myPane.XAxis.Scale.Min = -80;
            zgc.MasterPane[0].IsFontsScaled = false;
            myPane.XAxis.Scale.MinorStep = 10;
            myPane.XAxis.Scale.MajorStep = 10;
            myPane.YAxis.Scale.MinorStep = 1;
            myPane.YAxis.Scale.MajorStep = 1;
        }


        //-------------------------------------------------TEORIA -------------------------------------
        private void initGraphsFor1()
        {
            list1_1 = new PointPairList();
            list1_1.Add(-11, 0);
            list1_1.Add(-11, 1);
            list1_1.Add(11, 1);
            list1_1.Add(11, 0);

            GraphPane myPane = zedGraphControl1.GraphPane;
            LineItem myCurve = myPane.AddCurve("", list1_1, Color.Green, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zedGraphControl1.Refresh();

            list1_2 = new PointPairList();
            list1_2.Add(-40, 0);
            list1_2.Add(0, 1);
            list1_2.Add(0, 0);

            GraphPane myPane2 = zedGraphControl2.GraphPane;
            LineItem myCurve2 = myPane2.AddCurve("", list1_2, Color.Blue, SymbolType.None);
            myCurve2.Line.Width = 2.0F;
            zedGraphControl2.Refresh();

            list1_3 = new PointPairList();
            list1_3.Add(-40, 0);
            list1_3.Add(0, 1);

            GraphPane myPane3 = zedGraphControl3.GraphPane;
            LineItem myCurve3 = myPane3.AddCurve("", list1_3, Color.White, SymbolType.None);
            myCurve3.Line.Width = 2.0F;
            zedGraphControl3.Refresh();
        }

        private void switchFor1()
        {

            list1_3 = new PointPairList();
            list1_3.Add(0, 0);
            list1_3.Add(0, 1);
            list1_3.Add(40, 0);

            GraphPane myPane = zedGraphControl2.GraphPane;
            myPane.CurveList.Clear();
            LineItem myCurve = myPane.AddCurve("", list1_3, Color.Orange, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zedGraphControl2.Refresh();
        }

        //teoria, krok 2
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
            label21.Text = "f1(";
            label14.Text = "f2(-";
            label22.Text = "Zmienne zamienione -->";
            label23.Text = "Zmienne zamienione -->";
            switchFor1();
            button3.Enabled = true;
            textBox1.Text = "Zmienne zostały zamienione. Teraz funkcja f2 jest odwrócona, funkcja f1 pozostała niezmieniona.";
            textBox1.BackColor = Color.Honeydew;
        }

        int[] data = {1, 1, 2, 2, 3, 4, 5, 6, 8, 9, 11, 12, 14, 16, 18, 20, 23, 25, 28, 30, 33, 35, 38, 40, 43, 45, 48, 50, 53, 55, 58, 60, 63, 65, 68, 70, 73, 75, 72, 70, 67, 64, 61, 58, 54, 51, 47, 44, 40, 36, 32, 28, 23, 19, 14, 10, 5, 0};

        private void animateFor1()
        {
            int counter = -1;
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.CurveList.Clear();
            PointPairList tempList;
            PointPairList tempListForThird;
            LineItem tempC = null;
            LineItem tempCB = null;
            GraphPane myPane = zedGraphControl2.GraphPane;
            GraphPane myPane2 = zedGraphControl3.GraphPane;
            int step = -72;

            LineItem myCurve2 = myPane.AddCurve("", list1_1, Color.Transparent, SymbolType.None);
            myCurve2.Line.Fill = new Fill(Color.FromArgb(200, Color.White));


            while (step < 13)
            {
                Thread.Sleep(speed);
                tempList = new PointPairList();
                tempList.Add(step, 0);
                tempList.Add(step, 1);
                tempList.Add(step+40, 0);

                if (step == -47)
                {
                    counter = 0;
                }

                //wykres calki
                if (counter > 0)
                {
                    tempListForThird = new PointPairList();
                    for (int i = 0; i < counter; i++)
                    {
                        //String lol = "0," + data[i].ToString();
                        double res = (double)data[i] / 100;
                        //Double.TryParse(lol, out res);
                        int x = -47 + i;
                        tempListForThird.Add(x, (double)res);

                    }
                    if (tempCB != null)
                    {
                        myPane2.CurveList.Remove(tempCB);
                    }
                    LineItem myCurve3 = myPane2.AddCurve("", tempListForThird, Color.Red, SymbolType.None);
                    tempCB = myCurve3;
                    myCurve3.Line.Width = 2.0F;

                }
                //zmiana labeli
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            label3.Text = step.ToString();
                            label5.Text = step.ToString();
                            if (counter != -1 && counter < data.Length)
                            {
                                label6.Text = "0," + data[counter].ToString();
                            }
                        }));
                }
                if (counter != -1 && counter < data.Length)
                {
                    counter++;
                }

                //dodanie krzywej
                if (tempC != null)
                {
                    myPane.CurveList.Remove(tempC);
                }
                
                LineItem myCurve = myPane.AddCurve("", tempList, Color.Red, SymbolType.None);
                myCurve.Line.Fill = new Fill(Color.Red);
                tempC = myCurve;
                myCurve.Line.Width = 2.0F;
   
                //odswiezenie grafow
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            zedGraphControl2.Refresh();
                            zedGraphControl3.Refresh();
                        }));
                }


                //pauza w srodku
                if (step == -11)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate
                            {
                                button9.Text = "Kontynuuj";
                                button9.BackColor = Color.Gold;
                                label24.Visible = true;
                            }));
                    }
                    animate.Suspend();
                }
                step++;
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = "Obliczana jest wartość splotu dla kolejnych t. Wartość funkcji spolitu jest równa polu pod iloczynem f1 i f2. Dla każdego t wartość ta zaznaczana jest na ostatnim wykresie.";
            textBox1.BackColor = Color.LightYellow;

            label6.Text = "0,0";

            label22.Visible = false;
            label23.Visible = false;
            if (animate.IsAlive)
            {
                if (animate.ThreadState == ThreadState.Suspended) animate.Resume();
                animate.Abort();
            }
            animate = new Thread(new ThreadStart(animateFor1));
            animate.Start();
            //animate1_2();
        }

        private void speed1_Scroll(object sender, EventArgs e)
        {
            speed = speed1.Maximum - speed1.Value;
        }

        //pauzowanie animacji teorii
        private void button9_Click(object sender, EventArgs e)
        {
            button9.BackColor = Color.Transparent;
            if (String.Equals(button9.Text, "Pauza"))
            {
                button9.Text = "Kontynuuj";
                if (animate.IsAlive) animate.Suspend();
            }
            else
            {
                button9.Text = "Pauza";
                if (animate.IsAlive) animate.Suspend();
                if (animate.IsAlive && animate.ThreadState == ThreadState.Suspended) animate.Resume();
            }
        }

        //reset 1
        private void button11_Click(object sender, EventArgs e)
        {
            resetFor1();
        }

        private void resetFor1()
        {
            if (animate.IsAlive)
            {
                if (animate.ThreadState == ThreadState.Suspended) animate.Resume();
                animate.Abort();
            }
            loadGraphPane(zedGraphControl1);
            loadGraphPane(zedGraphControl2);
            loadGraphPane(zedGraphControl3);
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.CurveList.Clear();
            initGraphsFor1();

            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            label21.Text = "f1(t";
            label14.Text = "f2(t";

            textBox1.Text = polish.tekst_2_1;
            textBox1.BackColor = Color.WhiteSmoke;
            label22.Visible = false;
            label23.Visible = false;

            button2.Enabled = false;
            button3.Enabled = false;
            label24.Visible = false;

            label22.Text = "Nastąpi zamiana zmiennych -->";
            label23.Text = "Nastąpi zamiana zmiennych -->";
            label3.Text = "t";
            label5.Text = "t";

        }

        //krok pierwszy teorii
        private void button1_Click(object sender, EventArgs e)
        {
            resetFor1();
            textBox1.Text = "Nastąpi zamiana zmiennych: f1(t) -> f1(tau) oraz f2(t) -> f2(-tau). W wyniku zamiany funkcja f2 zostanie odwrócona.";
            textBox1.BackColor = Color.LightYellow;
            label22.Visible = true;
            label23.Visible = true;
            button2.Enabled = true;

        }

        //---------------------------------------------- ILLUSTRATION 1 ----------------------------------------
        private void initGraphsFor2()
        {
            list2_1 = new PointPairList();
            list2_1.Add(0, 0);
            list2_1.Add(0, 1);

            GraphPane myPane = zgc21.GraphPane;
            LineItem myCurve = myPane.AddCurve("", list2_1, Color.Green, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc21.Refresh();

            list2_2 = new PointPairList();
            list2_2.Add(-40, 0);
            list2_2.Add(0, 1);
            list2_2.Add(0, 0);

            GraphPane myPane2 = zgc22.GraphPane;
            LineItem myCurve2 = myPane2.AddCurve("", list2_2, Color.Blue, SymbolType.None);
            myCurve2.Line.Width = 2.0F;
            zgc22.Refresh();

            list1_3 = new PointPairList();
            list1_3.Add(-40, 0);
            list1_3.Add(0, 1);

            GraphPane myPane3 = zgc23.GraphPane;
            LineItem myCurve3 = myPane3.AddCurve("", list1_3, Color.White, SymbolType.None);
            myCurve3.Line.Width = 2.0F;
            zgc23.Refresh();
        }

        private void switchFor2()
        {

            list2_3 = new PointPairList();
            list2_3.Add(0, 0);
            list2_3.Add(0, 1);
            list2_3.Add(40, 0);

            GraphPane myPane = zgc22.GraphPane;
            myPane.CurveList.Clear();
            LineItem myCurve = myPane.AddCurve("", list2_3, Color.Orange, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc22.Refresh();
        }

        private void alg21_Click(object sender, EventArgs e)
        {
            resetFor2();
            tb2.Text = "Nastąpi zamiana zmiennych: f1(t) -> f1(tau) oraz f2(t) -> f2(-tau). W wyniku zamiany funkcja f2 zostanie odwrócona.";
            tb2.BackColor = Color.LightYellow;
            label25.Visible = true;
            label26.Visible = true;
            alg22.Enabled = true;
        }

        private void alg22_Click(object sender, EventArgs e)
        {
            switchFor2();
            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            label28.Text = "f1(";
            label34.Text = "f2(-";
            label25.Text = "Zmienne zamienione -->";
            label26.Text = "Zmienne zamienione -->";
            alg23.Enabled = true;
            tb2.Text = "Zmienne zostały zamienione. Teraz funkcja f2 jest odwrócona, funkcja f1 pozostała niezmieniona.";
            tb2.BackColor = Color.Honeydew;
        }

        private void alg23_Click(object sender, EventArgs e)
        {
            tb2.Text = "Obliczana jest wartość splotu dla kolejnych t. Wartość funkcji splotu jest równa polu pod iloczynem f1 i f2. Dla każdego t wartość ta zaznaczana jest na ostatnim wykresie.";
            tb2.BackColor = Color.LightYellow;

            vallabel23.Text = "0,0";

            label26.Visible = false;
            label25.Visible = false;
            if (animate2.IsAlive)
            {
                if (animate2.ThreadState == ThreadState.Suspended) animate2.Resume();
                animate2.Abort();
            }
            animate2 = new Thread(new ThreadStart(animateFor2));
            animate2.Start();
        }

        private void pauza2_Click(object sender, EventArgs e)
        {
            pauza2.BackColor = Color.Transparent;
            if (String.Equals(pauza2.Text, "Pauza"))
            {
                pauza2.Text = "Kontynuuj";
                if (animate2.IsAlive) animate2.Suspend();
            }
            else
            {
                pauza2.Text = "Pauza";
                if (animate2.IsAlive) animate2.Suspend();
                if (animate2.IsAlive && animate2.ThreadState == ThreadState.Suspended) animate2.Resume();
            }
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            resetFor2();
        }

        private void resetFor2()
        {
            if (animate2.IsAlive)
            {
                if (animate2.ThreadState == ThreadState.Suspended) animate2.Resume();
                animate2.Abort();
            }
            loadGraphPane(zgc21);
            loadGraphPane(zgc22);
            loadGraphPane(zgc23);
            zgc21.GraphPane.CurveList.Clear();
            zgc22.GraphPane.CurveList.Clear();
            zgc23.GraphPane.CurveList.Clear();
            initGraphsFor2();

            pictureBox16.Visible = false;
            pictureBox17.Visible = false;

            label28.Text = "f1(t";
            label34.Text = "f2(t";
            label25.Text = "Nastąpi zamiana zmiennych -->";
            label26.Text = "Nastąpi zamiana zmiennych -->";
            tb2.Text = polish.tekst_2_1;
            tb2.BackColor = Color.WhiteSmoke;
            label25.Visible = false;
            label26.Visible = false;

            alg22.Enabled = false;
            alg23.Enabled = false;
            infolabel2.Visible = false;
            vallabel21.Text = "t";
            vallabel22.Text = "t";
            vallabel23.Text = "?";
        }

        int[] data21 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 5, 8, 10, 13, 15, 17, 20, 22, 25, 28, 30, 32, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57, 60, 63, 65, 68, 70, 73, 75, 77, 80, 82, 85, 88, 90, 93, 95, 98, 49, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private void animateFor2()
        {
            int counter = 0;
            zgc22.GraphPane.CurveList.Clear();
            zgc23.GraphPane.CurveList.Clear();
            PointPairList tempList;
            PointPairList tempListForThird;
            LineItem tempC = null;
            LineItem tempCB = null;
            GraphPane myPane = zgc22.GraphPane;
            GraphPane myPane2 = zgc23.GraphPane;
            int step = -72;

            LineItem myCurve2 = myPane.AddCurve("", list2_1, Color.Transparent, SymbolType.None);
            myCurve2.Line.Fill = new Fill(Color.FromArgb(200, Color.White));


            while (step < 33)
            {
                Thread.Sleep(speed_2);
                tempList = new PointPairList();
                tempList.Add(step, 0);
                tempList.Add(step, 1);
                tempList.Add(step + 40, 0);

                tempListForThird = new PointPairList();
                for (int i = 0; i < counter; i++)
                {
                    double res = (double)data21[i] / 100;
                    int x = i-72;
                    tempListForThird.Add(x, (double)res);

                }
                if (tempCB != null)
                {
                    myPane2.CurveList.Remove(tempCB);
                }
                LineItem myCurve3 = myPane2.AddCurve("", tempListForThird, Color.Red, SymbolType.None);
                tempCB = myCurve3;
                myCurve3.Line.Width = 2.0F;

                //zmiana labeli
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            vallabel21.Text = step.ToString();
                            vallabel22.Text = step.ToString();
                            if (counter != -1 && counter < data21.Length)
                            {
                                vallabel23.Text = "0," + data21[counter].ToString();
                            }
                        }));
                }
                if (counter != -1 && counter < data21.Length)
                {
                    counter++;
                }

                //dodanie krzywej
                if (tempC != null)
                {
                    myPane.CurveList.Remove(tempC);
                }

                LineItem myCurve = myPane.AddCurve("", tempList, Color.Red, SymbolType.None);
                myCurve.Line.Fill = new Fill(Color.Red);
                tempC = myCurve;
                myCurve.Line.Width = 2.0F;

                //odswiezenie grafow
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            zgc22.Refresh();
                            zgc23.Refresh();
                        }));
                }


                //pauza w srodku
                if (step == -11)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate
                            {
                                pauza2.Text = "Kontynuuj";
                                pauza2.BackColor = Color.Gold;
                                infolabel2.Visible = true;
                            }));
                    }
                    animate2.Suspend();
                }
                step++;
            }
        }

        //--------------------------------------------- ILLUSTRATION 2 -------------------------------

        private void initGraphsFor3()
        {
            list3_1 = new PointPairList();
            list3_1.Add(-10, 0);
            list3_1.Add(-10,1);
            list3_1.Add(10, 1);
            list3_1.Add(10,0);

            GraphPane myPane = zgc31.GraphPane;
            LineItem myCurve = myPane.AddCurve("", list3_1, Color.Green, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc31.Refresh();

            list3_2 = new PointPairList();
            list3_2.Add(-10, 0);
            list3_2.Add(-10, 1);
            list3_2.Add(10, 1);
            list3_2.Add(10, 0);

            GraphPane myPane2 = zgc32.GraphPane;
            LineItem myCurve2 = myPane2.AddCurve("", list3_2, Color.Blue, SymbolType.None);
            myCurve2.Line.Width = 2.0F;
            zgc32.Refresh();

            list1_3 = new PointPairList();
            list1_3.Add(-40, 0);
            list1_3.Add(0, 1);

            GraphPane myPane3 = zgc33.GraphPane;
            LineItem myCurve3 = myPane3.AddCurve("", list1_3, Color.White, SymbolType.None);
            myCurve3.Line.Width = 2.0F;
            zgc33.Refresh();
        }

        private void switchFor3()
        {

/*            list3_2 = new PointPairList();
            list3_2.Add(-10, 0);
            list3_2.Add(-10, 1);
            list3_2.Add(10, 1);
            list3_2.Add(10, 0);
            */
            GraphPane myPane = zgc32.GraphPane;
            myPane.CurveList.Clear();
            LineItem myCurve = myPane.AddCurve("", list3_2, Color.Orange, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc32.Refresh();
        }

        private void alg31_Click(object sender, EventArgs e)
        {
            resetFor3();
            tb3.Text = "Nastąpi zamiana zmiennych: f1(t) -> f1(tau) oraz f2(t) -> f2(-tau). W wyniku zamiany żadna funkcja nie została odwrócona.";
            tb3.BackColor = Color.LightYellow;
            desclabel31.Visible = true;
            desclabel32.Visible = true;
            alg32.Enabled = true;
        }

        private void alg32_Click(object sender, EventArgs e)
        {
            switchFor3();
            pictureBox21.Visible = true;
            pictureBox22.Visible = true;
            f1label3.Text = "f1(";
            f2label3.Text = "f2(-";
            desclabel31.Text = "Zmienne zamienione -->";
            desclabel32.Text = "Zmienne zamienione -->";
            alg33.Enabled = true;
            tb3.Text = "Zmienne zostały zamienione. Funkcja f1 i f2 pozostała niezmieniona.";
            tb3.BackColor = Color.Honeydew;
        }

        private void alg33_Click(object sender, EventArgs e)
        {
            tb3.Text = "Obliczana jest wartość splotu dla kolejnych t. Wartość funkcji splotu jest równa polu pod iloczynem f1 i f2. Dla każdego t wartość ta zaznaczana jest na ostatnim wykresie.";
            tb3.BackColor = Color.LightYellow;

            vallabel33.Text = "0,0";

            desclabel31.Visible = false;
            desclabel32.Visible = false;
            if (animate3.IsAlive)
            {
                if (animate3.ThreadState == ThreadState.Suspended) animate3.Resume();
                animate3.Abort();
            }
            animate3 = new Thread(new ThreadStart(animateFor3));
            animate3.Start();
        }

        private void pauza3_Click(object sender, EventArgs e)
        {
            pauza3.BackColor = Color.Transparent;
            if (String.Equals(pauza3.Text, "Pauza"))
            {
                pauza3.Text = "Kontynuuj";
                if (animate3.IsAlive) animate3.Suspend();
            }
            else
            {
                pauza3.Text = "Pauza";
                if (animate3.IsAlive) animate3.Suspend();
                if (animate3.IsAlive && animate3.ThreadState == ThreadState.Suspended) animate3.Resume();
            }
        }

        private void reset3_Click(object sender, EventArgs e)
        {
            resetFor3();
        }

        private void resetFor3()
        {
            if (animate3.IsAlive)
            {
                if (animate3.ThreadState == ThreadState.Suspended) animate3.Resume();
                animate3.Abort();
            }
            loadGraphPane(zgc31);
            loadGraphPane(zgc32);
            loadGraphPane(zgc33);
            zgc31.GraphPane.CurveList.Clear();
            zgc32.GraphPane.CurveList.Clear();
            zgc33.GraphPane.CurveList.Clear();
            initGraphsFor3();

            pictureBox21.Visible = false;
            pictureBox22.Visible = false;

            f1label3.Text = "f1(t";
            f2label3.Text = "f2(t";
            desclabel31.Text = "Zmienne zamienione -->";
            desclabel32.Text = "Zmienne zamienione -->";
            tb3.Text = polish.tekst_2_1;
            tb3.BackColor = Color.WhiteSmoke;
            desclabel31.Visible = false;
            desclabel32.Visible = false;

            alg32.Enabled = false;
            alg33.Enabled = false;
            infolabel3.Visible = false;

            vallabel31.Text = "t";
            vallabel32.Text = "t";
            vallabel33.Text = "?";
        }
        
        int[] data3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 95, 90, 85, 80, 75, 70, 65, 60, 55, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void animateFor3()
        {
            int counter = 0;
            zgc32.GraphPane.CurveList.Clear();
            zgc33.GraphPane.CurveList.Clear();
            PointPairList tempList;
            PointPairList tempListForThird;
            LineItem tempC = null;
            LineItem tempCB = null;
            GraphPane myPane = zgc32.GraphPane;
            GraphPane myPane2 = zgc33.GraphPane;
            int step = -72;

            LineItem myCurve2 = myPane.AddCurve("", list3_1, Color.Transparent, SymbolType.None);
            myCurve2.Line.Fill = new Fill(Color.FromArgb(200, Color.White));


            while (step < 33)
            {
                Thread.Sleep(speed_3);
                tempList = new PointPairList();
                tempList.Add(step-10, 0);
                tempList.Add(step-10, 1);
                tempList.Add(step + 10, 1);
                tempList.Add(step + 10, 0);

                tempListForThird = new PointPairList();
                for (int i = 0; i < counter; i++)
                {
                    double res = (double)data3[i] / 100;
                    int x = i - 72;

                        tempListForThird.Add(x, (double)res);


                }
                if (tempCB != null)
                {
                    myPane2.CurveList.Remove(tempCB);
                }
                LineItem myCurve3 = myPane2.AddCurve("", tempListForThird, Color.Red, SymbolType.None);
                tempCB = myCurve3;
                myCurve3.Line.Width = 2.0F;

                //zmiana labeli
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            vallabel31.Text = step.ToString();
                            vallabel32.Text = step.ToString();
                            if (counter != -1 && counter < data3.Length)
                            {
                                double res = (double)data3[counter] / 100;
                                vallabel33.Text = res.ToString();
                            }
                        }));
                }
                if (counter != -1 && counter < data3.Length)
                {
                    counter++;
                }

                //dodanie krzywej
                if (tempC != null)
                {
                    myPane.CurveList.Remove(tempC);
                }

                LineItem myCurve = myPane.AddCurve("", tempList, Color.Red, SymbolType.None);
                myCurve.Line.Fill = new Fill(Color.Red);
                tempC = myCurve;
                myCurve.Line.Width = 2.0F;

                //odswiezenie grafow
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            zgc32.Refresh();
                            zgc33.Refresh();
                        }));
                }


                //pauza w srodku
                if (step == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate
                            {
                                pauza3.Text = "Kontynuuj";
                                pauza3.BackColor = Color.Gold;
                                infolabel3.Visible = true;
                            }));
                    }
                    animate3.Suspend();
                }
                step++;
            }
        }


        
        private void speed2_Scroll(object sender, EventArgs e)
        {
            speed_2 = speed3.Maximum -speed2.Value;
        }

        private void speed3_Scroll(object sender, EventArgs e)
        {
            speed_3 = speed3.Maximum -speed3.Value;
        }

        //---------------------------------ILLUSTRATION 3 -----------------------------------------------


        private void initGraphsFor4()
        {
            list4_1 = new PointPairList();
            list4_1.Add(-20, 0);
            list4_1.Add(0, 1);
            list4_1.Add(20, 0);

            GraphPane myPane = zgc41.GraphPane;
            LineItem myCurve = myPane.AddCurve("", list4_1, Color.Green, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc41.Refresh();

            list4_2 = new PointPairList();
            list4_2.Add(-20, 0);
            list4_2.Add(0, 1);
            list4_2.Add(20, 0);

            GraphPane myPane2 = zgc42.GraphPane;
            LineItem myCurve2 = myPane2.AddCurve("", list4_2, Color.Blue, SymbolType.None);
            myCurve2.Line.Width = 2.0F;
            zgc42.Refresh();

            list1_3 = new PointPairList();
            list1_3.Add(-40, 0);
            list1_3.Add(0, 1);

            GraphPane myPane3 = zgc43.GraphPane;
            LineItem myCurve3 = myPane3.AddCurve("", list1_3, Color.White, SymbolType.None);
            myCurve3.Line.Width = 2.0F;
            zgc43.Refresh();
        }

        private void switchFor4()
        {
            GraphPane myPane = zgc42.GraphPane;
            myPane.CurveList.Clear();
            LineItem myCurve = myPane.AddCurve("", list4_2, Color.Orange, SymbolType.None);
            myCurve.Line.Width = 2.0F;
            zgc42.Refresh();
        }


        private void alg41_Click(object sender, EventArgs e)
        {
            resetFor4();
            tb4.Text = "Nastąpi zamiana zmiennych: f1(t) -> f1(tau) oraz f2(t) -> f2(-tau). W wyniku zamiany żadna funkcja nie została odwrócona.";
            tb4.BackColor = Color.LightYellow;
            desclabel41.Visible = true;
            desclabel42.Visible = true;
            alg42.Enabled = true;
        }

        private void alg42_Click(object sender, EventArgs e)
        {
            switchFor4();
            pictureBox26.Visible = true;
            pictureBox27.Visible = true;
            f1label4.Text = "f1(";
            f2label4.Text = "f2(-";
            desclabel41.Text = "Zmienne zamienione -->";
            desclabel42.Text = "Zmienne zamienione -->";
            alg43.Enabled = true;
            tb4.Text = "Zmienne zostały zamienione. Funkcja f1 i f2 pozostała niezmieniona.";
            tb4.BackColor = Color.Honeydew;
        }

        private void alg43_Click(object sender, EventArgs e)
        {
            tb4.Text = "Obliczana jest wartość splotu dla kolejnych t. Wartość funkcji splotu jest równa polu pod iloczynem f1 i f2. Dla każdego t wartość ta zaznaczana jest na ostatnim wykresie.";
            tb4.BackColor = Color.LightYellow;

            vallabel43.Text = "0,0";

            desclabel41.Visible = false;
            desclabel42.Visible = false;
            if (animate4.IsAlive)
            {
                if (animate4.ThreadState == ThreadState.Suspended) animate4.Resume();
                animate4.Abort();
            }
            animate4 = new Thread(new ThreadStart(animateFor4));
            animate4.Start();
        }

        private void pauza4_Click(object sender, EventArgs e)
        {
            pauza4.BackColor = Color.Transparent;
            if (String.Equals(pauza4.Text, "Pauza"))
            {
                pauza4.Text = "Kontynuuj";
                if (animate4.IsAlive) animate4.Suspend();
            }
            else
            {
                pauza4.Text = "Pauza";
                if (animate4.IsAlive) animate4.Suspend();
                if (animate4.IsAlive && animate4.ThreadState == ThreadState.Suspended) animate4.Resume();
            }
        }

        private void reset4_Click(object sender, EventArgs e)
        {
            resetFor4();
        }

        private void resetFor4()
        {
            if (animate4.IsAlive)
            {
                if (animate4.ThreadState == ThreadState.Suspended) animate4.Resume();
                animate4.Abort();
            }
            loadGraphPane(zgc41);
            loadGraphPane(zgc42);
            loadGraphPane(zgc43);
            zgc41.GraphPane.CurveList.Clear();
            zgc42.GraphPane.CurveList.Clear();
            zgc43.GraphPane.CurveList.Clear();
            initGraphsFor4();

            pictureBox27.Visible = false;
            pictureBox26.Visible = false;

            f1label4.Text = "f1(t";
            f2label4.Text = "f2(t";
            desclabel41.Text = "Zmienne zamienione -->";
            desclabel42.Text = "Zmienne zamienione -->";
            tb4.Text = polish.tekst_2_1;
            tb4.BackColor = Color.WhiteSmoke;
            desclabel41.Visible = false;
            desclabel42.Visible = false;

            vallabel41.Text = "t";
            vallabel42.Text = "t";
            vallabel43.Text = "?";

            alg42.Enabled = false;
            alg43.Enabled = false;
            infolabel4.Visible = false;
        }

        private void speed4_Scroll(object sender, EventArgs e)
        {
            speed_4 = speed4.Maximum - speed4.Value;
        }


        int[] data4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,1,2,3,4,5,6,7,8,9,10,11,13,14,16,17,19,20,22,23,25,27,30,33,35,38,40,43,45,48,50,55,60,65,70,75,80,85,90,95,100,95,90,85,80,75,70,65,60,55,50,48,45,43,40,38,35,33,30,27,25,23,22,20,19,17,16,14,13,11,10,9,8,7,6,5,4,3,2,1,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
       
        private void animateFor4()
        {
            int counter = 0;
            zgc42.GraphPane.CurveList.Clear();
            zgc43.GraphPane.CurveList.Clear();
            PointPairList tempList;
            PointPairList tempListForThird;
            LineItem tempC = null;
            LineItem tempCB = null;
            GraphPane myPane = zgc42.GraphPane;
            GraphPane myPane2 = zgc43.GraphPane;
            int step = -72;

            LineItem myCurve2 = myPane.AddCurve("", list4_1, Color.Transparent, SymbolType.None);
            myCurve2.Line.Fill = new Fill(Color.FromArgb(200, Color.White));


            while (step < 50)
            {
                Thread.Sleep(speed_4);
                tempList = new PointPairList();
                tempList.Add(step -20, 0);
                tempList.Add(step , 1);
                tempList.Add(step + 20, 0);

                tempListForThird = new PointPairList();
                for (int i = 0; i < counter; i++)
                {
                    double res = (double)data4[i+20] / 100;
                    int x = i - 72;

                    tempListForThird.Add(x, (double)res);


                }
                if (tempCB != null)
                {
                    myPane2.CurveList.Remove(tempCB);
                }
                LineItem myCurve3 = myPane2.AddCurve("", tempListForThird, Color.Red, SymbolType.None);
                tempCB = myCurve3;
                myCurve3.Line.Width = 2.0F;

                //zmiana labeli
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            vallabel41.Text = step.ToString();
                            vallabel42.Text = step.ToString();
                            double res = (double) data4[counter+20] / 100;
                            vallabel43.Text = res.ToString();
                        }));
                }
                counter++;

                //dodanie krzywej
                if (tempC != null)
                {
                    myPane.CurveList.Remove(tempC);
                }

                LineItem myCurve = myPane.AddCurve("", tempList, Color.Red, SymbolType.None);
                myCurve.Line.Fill = new Fill(Color.Red);
                tempC = myCurve;
                myCurve.Line.Width = 2.0F;

                //odswiezenie grafow
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(
                        delegate
                        {
                            zgc42.Refresh();
                            zgc43.Refresh();
                        }));
                }


                //pauza w srodku
               if (step == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate
                            {
                                pauza4.Text = "Kontynuuj";
                                pauza4.BackColor = Color.Gold;
                                infolabel4.Visible = true;
                            }));
                    }
                    animate4.Suspend();
                }
                step++;
            }
        }


    }
}


