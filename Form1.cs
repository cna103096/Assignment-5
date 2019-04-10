using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5
{
    public partial class Form1 : Form
    {
        //initial puzzles
        public static int[,] easyPuzzlesInitial = new int[3, 9];
        public static int[,] mediumPuzzlesInitial = new int[3, 25];
        public static int[,] hardPuzzlesInitial = new int[3, 49];

        //puzzle solutions
        public static int[,] easyPuzzlesSolution = new int[3, 9];
        public static int[,] mediumPuzzlesSolution = new int[3, 25];
        public static int[,] hardPuzzlesSolution = new int[3, 49];

        //puzzles progress 
        public static int[,] easyPuzzlesProgress = new int[3, 9];
        public static int[,] mediumPuzzlesProgress = new int[3, 25];
        public static int[,] hardPuzzlesProgress = new int[3, 49];

        //completion times
        public static List<float> easyTime;
        public static List<float> mediumTime;
        public static List<float> hardTime;

        public Form1()
        {
            InitializeComponent();
            ComboBox_Difficulty.SelectedIndex = 0;
            Read_Files();
            

        }

        /*Read data
         * reads in the puzzles
         * filename is location of file, num is the puzzle number
         * */
         public void Read_Data(string fileName, uint num)
        {
            string read = "";
            using (StreamReader inFile = new StreamReader(fileName))
            {
                read = inFile.ReadLine();

                switch (read.Length)
                {
                    //easy
                    case 3:

                        int p = 0;
                        //iterate through puzzle
                        for (int j = 0; j < easyPuzzlesInitial.GetLength(1); j++)
                        {
                            //put number into array
                            easyPuzzlesInitial[num, j] = (int)Char.GetNumericValue( read[p] );
                            //iterate position of character in readline
                            p++;
                            //if p is done, get next line and reset p
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }
                            
                        }
                        read = inFile.ReadLine();
                        p = 0;
                        for (int j = 0; j < easyPuzzlesSolution.GetLength(1); j++)
                        {
                            easyPuzzlesSolution[num, j] = (int)Char.GetNumericValue(read[p]);

                            p++;
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }
                        }
                        //progress will always start at initial values
                        easyPuzzlesProgress = easyPuzzlesInitial;

                        break;
                    //medium
                    case 5:
                        p = 0;
                        //iterate through puzzle
                        for (int j = 0; j < mediumPuzzlesInitial.GetLength(1); j++)
                        {
                            //put number into array
                            mediumPuzzlesInitial[num, j] = (int)Char.GetNumericValue(read[p]);
                            //iterate position of character in readline
                            p++;
                            //if p is done, get next line and reset p
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }

                        }
                        read = inFile.ReadLine();
                        p = 0;
                        for (int j = 0; j < mediumPuzzlesSolution.GetLength(1); j++)
                        {
                            mediumPuzzlesSolution[num, j] = (int)Char.GetNumericValue(read[p]);

                            p++;
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }
                        }
                        //progress will always start at initial values
                        mediumPuzzlesProgress = mediumPuzzlesInitial;

                        break;
                    //hard
                    case 7:
                        p = 0;
                        //iterate through puzzle
                        for (int j = 0; j < hardPuzzlesInitial.GetLength(1); j++)
                        {
                            //put number into array
                            hardPuzzlesInitial[num, j] = (int)Char.GetNumericValue(read[p]);
                            //iterate position of character in readline
                            p++;
                            //if p is done, get next line and reset p
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }

                        }
                        read = inFile.ReadLine();
                        p = 0;
                        for (int j = 0; j < hardPuzzlesSolution.GetLength(1); j++)
                        {
                            hardPuzzlesSolution[num, j] = (int)Char.GetNumericValue(read[p]);

                            p++;
                            if (p == read.Length)
                            {
                                p = 0;
                                read = inFile.ReadLine();
                            }
                        }
                        //progress will always start at initial values
                        hardPuzzlesProgress = hardPuzzlesInitial;

                        break;

                }
            }
        }

        /* Read Files
         * calls the read data method for each file
         * */
         private void Read_Files()
        {
            //easy files
            Read_Data("..\\..\\a5/easy/e1.txt", 0);
            Read_Data("..\\..\\a5/easy/e2.txt", 1);
            Read_Data("..\\..\\a5/easy/e3.txt", 2);
            //medium files
            Read_Data("..\\..\\a5/medium/m1.txt", 0);
            Read_Data("..\\..\\a5/medium/m2.txt", 1);
            Read_Data("..\\..\\a5/medium/m3.txt", 2);
            //hard files
            Read_Data("..\\..\\a5/hard/h1.txt", 0);
            Read_Data("..\\..\\a5/hard/h2.txt", 1);
            Read_Data("..\\..\\a5/hard/h3.txt", 2);
        }


        /* Button Create Puzzle Click
         * Generates a new puzzle based on selected difficulty
         * */
        private void Button_Create_Puzzle_Click(object sender, EventArgs e)
        {
            //default to easy
            uint diff = 0;
            

            //easy
            if (ComboBox_Difficulty.SelectedIndex == 0)
            {
                diff = 0;
                Label_Difficulty.Text = "Easy Puzzle";
            }
            //medium
            if (ComboBox_Difficulty.SelectedIndex == 1)
            {
                diff = 1;
                Label_Difficulty.Text = "Medium Puzzle";
            }
            //hard
            if (ComboBox_Difficulty.SelectedIndex == 2)
            {
                diff = 2;
                Label_Difficulty.Text = "Hard Puzzle";
            }

            Reset_Values();
            Set_Difficulty(diff);
        }



        /*Reset Values
         * set all textboxes blank
         * */
        private void Reset_Values()
        {
            //clear everything
            Textbox_Puzzle_1.Clear();
            Textbox_Puzzle_2.Clear();
            Textbox_Puzzle_3.Clear();
            Textbox_Puzzle_4.Clear();
            Textbox_Puzzle_5.Clear();
            Textbox_Puzzle_6.Clear();
            Textbox_Puzzle_7.Clear();
            Textbox_Puzzle_8.Clear();
            Textbox_Puzzle_9.Clear();
            Textbox_Puzzle_10.Clear();
            Textbox_Puzzle_11.Clear();
            Textbox_Puzzle_12.Clear();
            Textbox_Puzzle_13.Clear();
            Textbox_Puzzle_14.Clear();
            Textbox_Puzzle_15.Clear();
            Textbox_Puzzle_16.Clear();
            Textbox_Puzzle_17.Clear();
            Textbox_Puzzle_18.Clear();
            Textbox_Puzzle_19.Clear();
            Textbox_Puzzle_20.Clear();
            Textbox_Puzzle_21.Clear();
            Textbox_Puzzle_22.Clear();
            Textbox_Puzzle_23.Clear();
            Textbox_Puzzle_24.Clear();
            Textbox_Puzzle_25.Clear();
            Textbox_Puzzle_26.Clear();
            Textbox_Puzzle_27.Clear();
            Textbox_Puzzle_28.Clear();
            Textbox_Puzzle_29.Clear();
            Textbox_Puzzle_30.Clear();
            Textbox_Puzzle_31.Clear();
            Textbox_Puzzle_32.Clear();
            Textbox_Puzzle_33.Clear();
            Textbox_Puzzle_34.Clear();
            Textbox_Puzzle_35.Clear();
            Textbox_Puzzle_36.Clear();
            Textbox_Puzzle_37.Clear();
            Textbox_Puzzle_38.Clear();
            Textbox_Puzzle_39.Clear();
            Textbox_Puzzle_40.Clear();
            Textbox_Puzzle_41.Clear();
        }

        /* Set Difficulty
         * 0 = Easy, 1 = Medium, 2 = Hard
         * */
        private void Set_Difficulty(uint difficulty)
        {
            //default to easy
            bool aSize = false;
            bool bSize = false;

            //row and column offsets
            /*              C
             *              B
             *              A
             *              A
             *              A
             *              B
             *              C
             * C B A A A B C
             * */
            int rowOffsetA = -110;
            int rowOffsetB = -1000;
            int rowOffsetC = -1000;

            int colOffsetA = -110;
            int colOffsetB = -1000;
            int colOffsetC = -1000;

            //medium
            if (difficulty >= 1)
            {
                bSize = true;
                rowOffsetA = -50;
                rowOffsetB = -50;
                rowOffsetC = -1000;

                colOffsetA = -50;
                colOffsetB = -50;
                colOffsetC = -1000;
            }
            //hard
            if (difficulty == 2)
            {
                aSize = true;
                rowOffsetA = 0;
                rowOffsetB = 0;
                rowOffsetC = 0;

                colOffsetA = 0;
                colOffsetB = 0;
                colOffsetC = 0;
            }

            //Hard Only
            //row 1
            Textbox_Puzzle_1.Visible = aSize;
            Textbox_Puzzle_2.Visible = aSize;
            Textbox_Puzzle_3.Visible = aSize;
            Textbox_Puzzle_4.Visible = aSize;
            Textbox_Puzzle_5.Visible = aSize;
            Textbox_Puzzle_6.Visible = aSize;
            Textbox_Puzzle_7.Visible = aSize;
            //row 2
            Textbox_Puzzle_8.Visible = aSize;
            Textbox_Puzzle_14.Visible = aSize;
            //row 3
            Textbox_Puzzle_15.Visible = aSize;
            Textbox_Puzzle_21.Visible = aSize;
            //row 4
            Textbox_Puzzle_22.Visible = aSize;
            Textbox_Puzzle_28.Visible = aSize;
            //row 5
            Textbox_Puzzle_29.Visible = aSize;
            Textbox_Puzzle_35.Visible = aSize;
            //row 6
            Textbox_Puzzle_36.Visible = aSize;
            Textbox_Puzzle_42.Visible = aSize;
            //row 7
            Textbox_Puzzle_43.Visible = aSize;
            Textbox_Puzzle_44.Visible = aSize;
            Textbox_Puzzle_45.Visible = aSize;
            Textbox_Puzzle_46.Visible = aSize;
            Textbox_Puzzle_47.Visible = aSize;
            Textbox_Puzzle_48.Visible = aSize;
            Textbox_Puzzle_49.Visible = aSize;


            //Medium Only
            //row 2
            Textbox_Puzzle_9.Visible = bSize;
            Textbox_Puzzle_10.Visible = bSize;
            Textbox_Puzzle_11.Visible = bSize;
            Textbox_Puzzle_12.Visible = bSize;
            Textbox_Puzzle_13.Visible = bSize;
            //row 3
            Textbox_Puzzle_16.Visible = bSize;
            Textbox_Puzzle_20.Visible = bSize;
            //row 4
            Textbox_Puzzle_23.Visible = bSize;
            Textbox_Puzzle_27.Visible = bSize;
            //row 5
            Textbox_Puzzle_30.Visible = bSize;
            Textbox_Puzzle_34.Visible = bSize;
            //row 6
            Textbox_Puzzle_37.Visible = bSize;
            Textbox_Puzzle_38.Visible = bSize;
            Textbox_Puzzle_39.Visible = bSize;
            Textbox_Puzzle_40.Visible = bSize;
            Textbox_Puzzle_41.Visible = bSize;

            
            //Sum Labels
            //row labels
            Label_Puzzle_R1.Location = new System.Drawing.Point(386 + rowOffsetC, 145);
            Label_Puzzle_R2.Location = new System.Drawing.Point(386 + rowOffsetB, 200);
            Label_Puzzle_R3.Location = new System.Drawing.Point(386 + rowOffsetA, 255);
            Label_Puzzle_R4.Location = new System.Drawing.Point(386 + rowOffsetA, 310);
            Label_Puzzle_R5.Location = new System.Drawing.Point(386 + rowOffsetA, 365);
            Label_Puzzle_R6.Location = new System.Drawing.Point(386 + rowOffsetB, 420);
            Label_Puzzle_R7.Location = new System.Drawing.Point(386 + rowOffsetC, 475);
            //row sum labels
            Label_Puzzle_Sum_R1.Location = new System.Drawing.Point(419 + rowOffsetC, 145);
            Label_Puzzle_Sum_R2.Location = new System.Drawing.Point(419 + rowOffsetB, 200);
            Label_Puzzle_Sum_R3.Location = new System.Drawing.Point(419 + rowOffsetA, 255);
            Label_Puzzle_Sum_R4.Location = new System.Drawing.Point(419 + rowOffsetA, 310);
            Label_Puzzle_Sum_R5.Location = new System.Drawing.Point(419 + rowOffsetA, 365);
            Label_Puzzle_Sum_R6.Location = new System.Drawing.Point(419 + rowOffsetB, 420);
            Label_Puzzle_Sum_R7.Location = new System.Drawing.Point(419 + rowOffsetC, 475);
            //diagonal labels
            Label_Puzzle_D1.Location = new System.Drawing.Point(386 + rowOffsetA, 109 + Math.Abs(colOffsetA));
            Label_Puzzle_D2.Location = new System.Drawing.Point(386 + rowOffsetA, 523 + colOffsetA);
            //diagonal sum labels
            Label_Puzzle_Sum_D1.Location = new System.Drawing.Point(419 + rowOffsetA, 88 + Math.Abs(colOffsetA));
            Label_Puzzle_Sum_D2.Location = new System.Drawing.Point(419 + rowOffsetA, 538 + colOffsetA);
            //column labels
            Label_Puzzle_C1.Location = new System.Drawing.Point(15, 523 + colOffsetC);
            Label_Puzzle_C2.Location = new System.Drawing.Point(67, 523 + colOffsetB);
            Label_Puzzle_C3.Location = new System.Drawing.Point(120, 523 + colOffsetA);
            Label_Puzzle_C4.Location = new System.Drawing.Point(173, 523 + colOffsetA);
            Label_Puzzle_C5.Location = new System.Drawing.Point(226, 523 + colOffsetA);
            Label_Puzzle_C6.Location = new System.Drawing.Point(279, 523 + colOffsetB);
            Label_Puzzle_C7.Location = new System.Drawing.Point(332, 523 + colOffsetC);
            //column sum labels
            Label_Puzzle_Sum_C1.Location = new System.Drawing.Point(15, 552 + colOffsetC);
            Label_Puzzle_Sum_C2.Location = new System.Drawing.Point(67, 552 + colOffsetB);
            Label_Puzzle_Sum_C3.Location = new System.Drawing.Point(120, 552 + colOffsetA);
            Label_Puzzle_Sum_C4.Location = new System.Drawing.Point(173, 552 + colOffsetA);
            Label_Puzzle_Sum_C5.Location = new System.Drawing.Point(226, 552 + colOffsetA);
            Label_Puzzle_Sum_C6.Location = new System.Drawing.Point(279, 552 + colOffsetB);
            Label_Puzzle_Sum_C7.Location = new System.Drawing.Point(332, 552 + colOffsetC);


        }

        /* Textbox Puzzle KeyPress
         * only allow numbers to be input
         * */
        private void Textbox_Puzzle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it is a control character or a digit, allow input
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            
        }
    }
}
